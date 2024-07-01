﻿using System.Text.RegularExpressions;

namespace TimedPower
{
    class AfterTimeValue
    {
        private static class MainData
        {
            private static int hours = 0;
            private static int minutes = 0;
            private static int seconds = 0;

            public static long Hours
            {
                get
                {
                    return hours;
                }
                set
                {
                    hours = (int)value;
                }
            }
            public static long Minutes
            {
                get
                {
                    return minutes;
                }
                set
                {
                    while (value >= 60)
                    {
                        Hours++;
                        value -= 60;
                    }
                    if(value < 0)
                    {
                        Hours--;
                        value = 59;
                    }
                    minutes = (int)value;
                }
            }
            public static long Seconds
            {
                get
                {
                    return seconds;
                }
                set
                {
                    while (value >= 60)
                    {
                        Minutes++;
                        value -= 60;
                    }
                    if (value < 0)
                    {
                        Minutes--;
                        value = 59;
                    }
                    seconds = (int)value;
                }
            }
        }

        #region 获取或设置时间值
#pragma warning disable CA1822 // 将成员标记为 static //这些成员不可被标记为 static
        /// <summary>
        /// 获取时间值
        /// </summary>
        public int[] TimeValue
        {
            get
            {
                return [(int)MainData.Hours, (int)MainData.Minutes, (int)MainData.Seconds];
            }
        }
        /// <summary>
        /// 获取或设置小时部分的数值
        /// </summary>
        public int OnlyHours
        {
            get
            {
                return (int)MainData.Hours;
            }
            set
            {
                MainData.Hours = value;
            }
        }
        /// <summary>
        /// 获取或设置分钟部分的数值
        /// </summary>
        public int OnlyMinutes
        {
            get
            {
                return (int)MainData.Minutes;
            }
            set
            {
                MainData.Minutes = value;
            }
        }
        /// <summary>
        /// 获取或设置秒部分的数值
        /// </summary>
        public int OnlySeconds
        {
            get
            {
                return (int)MainData.Seconds;
            }
            set
            {
                MainData.Seconds = value;
            }
        }
        /// <summary>
        /// 获取将所有时间合并计算为小时单位的值
        /// </summary>
        public float AllHours
        {
            get
            {
                return MainData.Hours + (float)MainData.Minutes / 60 + (float)MainData.Seconds / 60 / 60;
            }
        }
        /// <summary>
        /// 获取将所有时间合并计算为分钟单位的值
        /// </summary>
        public float AllMinutes
        {
            get
            {
                return MainData.Hours * 60 + MainData.Minutes + (float)MainData.Seconds / 60;
            }
        }
        /// <summary>
        /// 获取将所有时间合并计算为秒单位的值
        /// </summary>
        public long AllSeconds
        {
            get
            {
                return MainData.Hours * 60 * 60 + MainData.Minutes * 60 + MainData.Seconds;
            }
        }
        /// <summary>
        /// 设置时间值
        /// </summary>
        /// <param name="hours_">小时</param>
        /// <param name="minutes_">分钟</param>
        /// <param name="seconds_">秒</param>
        public void SetTimeValue(long hours = 0, long minutes = 0, long seconds = 0)
        {
            /*hours ??= MainData.Hours;
            minutes ??= MainData.Minutes;
            seconds ??= MainData.Seconds; //同 if (seconds_ == null) seconds_ = MainData.seconds;*/

            MainData.Hours = hours;
            MainData.Minutes = minutes;
            MainData.Seconds = seconds;
        }
        #endregion

        #region 格式化与格式化解析
        /// <summary>
        /// 获取格式化后的时间字符串
        /// </summary>
        /// <returns>返回string值</returns>
        public string GetFormatdTime()
        {
            return MainData.Hours.ToString().PadLeft(2,char.Parse("0")) + ":" + 
                   MainData.Minutes.ToString().PadLeft(2, char.Parse("0")) + ":" + 
                   MainData.Seconds.ToString().PadLeft(2, char.Parse("0"));
        }
        /// <summary>
        /// 获取格式化后更直观的文本，例如: 5分20秒，13min14s
        /// </summary>
        /// <param name="unit">时间使用的单位。cn: 中文单位; en: 英文单位</param>
        /// <returns>返回string值</returns>
        public string GetVisualTime(string unit = "cn")
        {
            string output = "";
            switch (unit)
            {
                case "cn":
                    {
                        if (MainData.Hours != 0) 
                        {
                            output += MainData.Hours.ToString();
                            if (MainData.Minutes == 0 && MainData.Seconds == 0) output +="小时";
                            else output += "时";
                        }
                        if (MainData.Minutes != 0)
                        {
                            output += MainData.Minutes.ToString();
                            if (MainData.Seconds == 0) output += "分钟";
                            else output += "分";
                        }
                        if (MainData.Seconds != 0)
                        {
                            output += MainData.Seconds.ToString() +"秒"; 
                        }
                    }
                    break;
                case "en":
                    {
                        if (MainData.Hours != 0) output += MainData.Hours.ToString()+"h";
                        if (MainData.Minutes != 0) output += MainData.Minutes.ToString()+"min";
                        if (MainData.Seconds != 0) output += MainData.Seconds.ToString() + "s";
                    }
                    break;
            }
            return output;
        }
        /// <summary>
        /// 将时间数据解析后存储入变量，例如对象: "1秒"，"5min"，"00:10:00"
        /// </summary>
        /// <param name="input">输入对象</param>
        /// <param name="typeID">执行的操作ID。
        /// 0: 将当前的数据以替换的形式存入变量; 
        /// 1: 将当前的数据添加到变量内</param>
        /// <returns>返回执行结果 done: 执行完成; error: 格式错误; ToBig: 数值过大</returns>
        public string FormatdInputTime(string input,int typeID=0)
        {
            static bool IsNumber(string input)
            {
                string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";
                Regex regex = new(pattern);
                return regex.IsMatch(input);
            }
            long[] timeTmp = new long[3];//临时时间值存储。h;min;s

            bool exist1 = false;//如果:存在
            bool exist2 = false;//如果秒分时关键字符存在
            if (input.IndexOf(":") != -1) exist1 = true;
            if (input.IndexOf("秒") != -1 || input.IndexOf("分") != -1 || input.IndexOf("时") != -1 ||
                input.IndexOf("s") != -1 || input.IndexOf("min") != -1 || input.IndexOf("h") != -1) exist2 = true;
            if (exist1 && !exist2)
            {
                string[] spStr = input.Split(":");
                if (spStr.Length == 3)
                {
                    string temp;
                    for (int i = 0; i < 3; i++)
                    {
                        temp = "";
                        for (int j = 0; j < spStr[i].Length; j++)
                        {
                            string oneStr = spStr[i].Substring(j, 1);
                            if (IsNumber(oneStr))
                            {
                                temp += oneStr;
                            }
                        }
                        try
                        {
                            timeTmp[i] = long.Parse(temp);
                        }
                        catch { goto errorExit; }
                    }
                }
                else
                {
                     goto errorExit;
                }
            }
            else if (exist2 && !exist1)
            {
                string temp = "";//临时
                for (int i = 0; i < input.Length; i++)
                {
                    string oneStr = input.Substring(i, 1);
                    if (IsNumber(oneStr))
                    {
                        temp += oneStr;
                    }
                    else
                    {
                        string addValue(int id)
                        {
                            try
                            {
                                switch (id)
                                {
                                    case 0:
                                        timeTmp[2] += long.Parse(temp); break;
                                    case 1:
                                        timeTmp[1] += long.Parse(temp); break;
                                    case 2:
                                        timeTmp[0] += long.Parse(temp); break;
                                }
                            }
                            catch {  return "err"; }
                            temp = "";
                            return "done";
                        }
                        switch (oneStr)
                        {
                            case "s":
                                if (addValue(0) == "err") goto errorExit; break;
                            case "秒":
                                if (i + 1 < input.Length)
                                {
                                    if (input.Substring(i + 1, 1) == "钟")
                                    {
                                        i++;
                                    }
                                }
                                if (addValue(0) == "err") goto errorExit;
                                break;
                            case "m":
                                if (i + 2 < input.Length)
                                {
                                    if (input.Substring(i + 1, 2) == "in")
                                    {
                                        i += 2;
                                    }
                                    else {  goto errorExit; }
                                }
                                else {  goto errorExit; }
                                if (addValue(1) == "err") goto errorExit;
                                break;
                            case "分":
                                if (i + 1 < input.Length)
                                {
                                    if (input.Substring(i + 1, 1) == "钟")
                                    {
                                        i++;
                                    }
                                }
                                if (addValue(1) == "err") goto errorExit;
                                break;
                            case "h":
                                if (addValue(2) == "err") goto errorExit; 
                                break;
                            case "小":
                                if (i + 1 < input.Length)
                                {
                                    if (input.Substring(i + 1, 1) == "时")
                                    {
                                        i++;
                                    }
                                    else {  goto errorExit; }
                                }
                                else {  goto errorExit; }
                                if (addValue(2) == "err") goto errorExit;
                                break;
                            case "时":
                                if (addValue(2) == "err") goto errorExit; 
                                break;
                            default:
                                 goto errorExit;
                        }
                    }
                }
            }
            else
            {
                string temp = "";
                for (int i = 0; i < input.Length; i++)
                {
                    string oneStr = input.Substring(i, 1);
                    if (IsNumber(oneStr))
                    {
                        temp += oneStr;
                    }
                }
                try
                {
                    timeTmp = [0, 0, long.Parse(temp)];
                }
                catch { goto errorExit; }
            }
            switch (typeID)
            {
                case 0:
                    MainData.Hours = timeTmp[0];
                    MainData.Minutes = timeTmp[1];
                    MainData.Seconds = timeTmp[2];
                    break;
                case 1:
                    MainData.Hours += timeTmp[0];
                    MainData.Minutes += timeTmp[1];
                    MainData.Seconds += timeTmp[2];
                    break;
            }
            if (MainData.Hours > 90000000) return "ToBig";
            return "done";
errorExit:;
            return "error";
        }
#pragma warning restore CA1822
        #endregion
    }
}

using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TimedPower {
	public struct ControlOverride {
		/// <summary>
		/// 通过反射获取基类的私有变量
		/// </summary>
		/// <param name="baseClass">基类</param>
		/// <param name="thisObj">当前对象</param>
		/// <param name="targetName">目标变量名</param>
		/// <returns></returns>
		static dynamic? GetPrivateVar(Type baseClass, object thisObj, string targetName) => 
			baseClass.GetField(targetName, BindingFlags.NonPublic | BindingFlags.Instance)
				?.GetValue(thisObj);

		public class PoisonTextBox_OR: PoisonTextBox {
			public override ContextMenuStrip ContextMenuStrip {
				get => GetPrivateVar(typeof(ReaLTaiizor.Controls.PoisonTextBox), this, "baseTextBox")!.ContextMenuStrip;
				set => GetPrivateVar(typeof(ReaLTaiizor.Controls.PoisonTextBox), this, "baseTextBox")!.ContextMenuStrip = value;
			}
		}
	}
}

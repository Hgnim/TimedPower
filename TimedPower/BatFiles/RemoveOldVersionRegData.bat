reg delete HKEY_CLASSES_ROOT\Directory\Background\shell\TimedPower /f
reg delete HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run /f /v "TimedPower"
timeout /t 3
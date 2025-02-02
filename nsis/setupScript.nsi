; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "定时电源"
!define PRODUCT_MAIN_EXE "定时电源.exe"
!define PRODUCT_NAME_EN "Timed Power"
!define PRODUCT_NAME_PJ "TimedPower"
!define PRODUCT_VERSION "2.8.7.20250201-pre3"
!define PRODUCT_PUBLISHER "Hgnim"
!define PRODUCT_WEB_SITE "https://github.com/Hgnim/TimedPower"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\${PRODUCT_MAIN_EXE}"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME_PJ}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

!define OUTPUT_FILE_NAME "${PRODUCT_NAME_PJ}_v${PRODUCT_VERSION}_Setup.exe"

SetCompressor lzma

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "..\TimedPower\TimedPower_logo.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "..\LICENSE"
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!define MUI_FINISHPAGE_RUN "$INSTDIR\${PRODUCT_MAIN_EXE}"
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

; Reserve files
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS

; MUI end ------

Name "${PRODUCT_NAME}"
OutFile "${OUTPUT_FILE_NAME}"
InstallDir "$PROGRAMFILES\${PRODUCT_NAME_PJ}"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

VIProductVersion "${PRODUCT_VERSION}"
; 文件信息
VIAddVersionKey "ProductName" "${PRODUCT_NAME_EN}"
VIAddVersionKey "ProductVersion" "${PRODUCT_VERSION}"
VIAddVersionKey "CompanyName" "${PRODUCT_PUBLISHER}"
VIAddVersionKey "LegalCopyright" "Copyright (C) 2024-2025 ${PRODUCT_PUBLISHER}, All rights reserved."
VIAddVersionKey "FileDescription" "${PRODUCT_NAME}"
VIAddVersionKey "FileVersion" "${PRODUCT_VERSION}"
VIAddVersionKey "InternalName" "${PRODUCT_NAME_PJ}"
VIAddVersionKey "OriginalFilename" "${OUTPUT_FILE_NAME}"

Section "主要文件" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite try

  SetOutPath "$INSTDIR"
  File /r "..\..\TimedPower_bin\*.*"

  CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME_EN}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME_EN}\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_MAIN_EXE}"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_MAIN_EXE}"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninstall.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\${PRODUCT_MAIN_EXE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninstall.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\${PRODUCT_MAIN_EXE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) 已成功地从你的计算机移除。"
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "你确实要完全移除 $(^Name) ，其及所有的组件？" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  RMDir /r "$INSTDIR"

  Delete "$DESKTOP\${PRODUCT_NAME}.lnk"
  Delete "$SMPROGRAMS\${PRODUCT_NAME_EN}\${PRODUCT_NAME}.lnk"

  RMDir "$SMPROGRAMS\${PRODUCT_NAME_EN}"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"

  SetAutoClose true
SectionEnd
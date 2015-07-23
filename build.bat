@echo off

if not exist "%~dp0\Thirdparty\ACT\Advanced Combat Tracker.exe" (
	echo エラー: "Thirdparty" ディレクトリに "Advanced Combat Tracker.exe" をコピーしてください。
	goto END
)

if not exist "%~dp0\Thirdparty\OverlayPlugin\OverlayPlugin.Core.dll" (
	echo エラー: "Thirdparty\OverlayPlugin" ディレクトリに "OverlayPlugin.Core.dll" をコピーしてください。
	goto END
)

if not exist "%~dp0\Thirdparty\OverlayPlugin\OverlayPlugin.Common.dll" (
	echo エラー: "Thirdparty\OverlayPlugin" ディレクトリに "OverlayPlugin.Common.dll" をコピーしてください。
	goto END
)

if not exist "%~dp0\Thirdparty\OverlayPlugin\HtmlRenderer.dll" (
	echo エラー: "Thirdparty\OverlayPlugin" ディレクトリに "HtmlRenderer.dll" をコピーしてください。
	goto END
)

set DOTNET_PATH=%windir%\Microsoft.NET\Framework\v4.0.30319
if not exist %DOTNET_PATH% (
	echo エラー: .NET Framework のディレクトリが見つかりません。ビルドを実行するためには .NET Framework 4.6がインストールされている必要があります。
	goto END
)

set MSBUILD_PATH="%ProgramFiles(x86)%\MSBuild\14.0"
if not exist %MSBUILD_PATH% (
	echo エラー: Microsoft Build Tool 2015 のディレクトリが見つかりません。ビルドを実行するためには Microsoft Build Tool 2015がインストールされている必要があります。
	goto END
)


%MSBUILD_PATH%\Bin\msbuild /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU" /p:OutputPath="%~dp0\Build" "%~dp0\EnmityPlugin.sln"

:END

# ビルド
./build.bat

# バージョン取得
$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("Build\EnmityOverlay.dll").FileVersion

# フォルダ名
$buildFolder = ".\Build"
$fullFolder = ".\Distribute\EnmityOverlay-" + $version

# フォルダが既に存在するなら消去
if ( Test-Path $fullFolder -PathType Container ) {
	Remove-Item -Recurse -Force $fullFolder
}

# フォルダ作成
New-Item -ItemType directory -Path $fullFolder
New-Item -ItemType directory -Path "$fullFolder\addons"

# full
xcopy /Y /R /S /EXCLUDE:full.exclude "$buildFolder\*" "$fullFolder"
mv "$fullFolder\EnmityOverlay.dll" "$fullFolder\addons"

cd Distribute
$folder = "EnmityOverlay-" + $version

# アーカイブ
& "C:\Program Files\7-Zip\7z.exe" "a" "$folder.zip" "$folder"

pause

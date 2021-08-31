[Reflection.Assembly]::LoadWithPartialName("System.IO.Compression.FileSystem")
$Compression = [System.IO.Compression.CompressionLevel]::Optimal
$IncludeBaseDirectory = $true

$OrigSource = "..\bin\Debug\"
$Source = "TNBase\"

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

Copy-Item -R $OrigSource $Source

$VersionStr = (Get-Item TNBase\TNBase.exe).VersionInfo.FileVersion
$Destination = "TNBase V$VersionStr.zip"

# For safety remove the Database (and any backups)
#Remove-Item TNBase\Resource\Listeners.s3db
Remove-Item TNBase\Resource\Listeners.s3db.bak
Remove-Item -R TNBase\app.publish

Write-Host "Zipping this folder: $Source"
Write-Host "Creating file: $Destination"

[System.IO.Compression.ZipFile]::CreateFromDirectory("$PSScriptRoot\$Source","$PSScriptRoot\$Destination",$Compression,$IncludeBaseDirectory)
Get-ChildItem "$PSScriptRoot\$Source" -Recurse | Remove-Item -Recurse -Force -Confirm:$false

git tag $VersionStr
Write-Host "Creating git tag: $VersionStr"

Remove-Item -R TNBase

Write-Host "Press any key to continue ..."
$host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
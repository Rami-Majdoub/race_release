@echo off
pushd "%~dp0"
powershell Compress-7Zip "Release" -ArchiveFileName "SampleX86.zip" -Format Zip
:exit
popd
@echo on
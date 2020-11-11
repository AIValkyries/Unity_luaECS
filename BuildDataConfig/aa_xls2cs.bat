@echo off
setlocal Enabledelayedexpansion

set SHEET_NAME=%1
set XLS_FILE_PATH=%2

echo. ==========================="%XLS_FILE_PATH%.%SHEET_NAME% to cs or bytes "===========================

set PROTO_2_CS=.\xls_2_cs
cd %PROTO_2_CS%

python xls_deploy_tool.py %SHEET_NAME% ..\DataConfig\%XLS_FILE_PATH%.xlsx c

dir *.proto /b >>protolist.txt

for /f "delims=." %%i in (protolist.txt) do protoc.exe --csharp_out=./ %%i.proto

::for /f "delims=." %%i in (protolist.txt) do ProtoGen\protogen.exe -i:%%i.proto -o:%%i.cs

cd ..

set ASSET_DATA_PATH=..\Assets\L_Resources\DataConfig
set ASSET_CS_PATH=..\Assets\L_Proto\ProtoConfig

copy %PROTO_2_CS%\*.data %ASSET_DATA_PATH%\*.bytes
copy %PROTO_2_CS%\*.cs %ASSET_CS_PATH%\*.cs

cd %PROTO_2_CS%

::ÒÆ³ýÁÙÊ±ÎÄ¼þ
del *.txt
del *.log
del *.cs
del *.data
del *.proto
del *_pb2.py
del *_pb2.pyc



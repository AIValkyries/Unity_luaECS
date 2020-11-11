setlocal Enabledelayedexpansion
@echo  off
echo ==================生成cs文件==================
echo.

set PROTO_GEN_EXE=.\proto2cs\protoc.exe
set PROTO_PATH=.\protocol

:: 解析文本文件 
for /f "delims=." %%i in (cs_proto_list.txt) do (
   set /a i+=1
   set array[!i!]=%%i
)

for /l %%i in (1,1,!i!) do  %PROTO_GEN_EXE% --csharp_out=./ %PROTO_PATH%/!array[%%i]!.proto

set CS_PATH=..\Assets\L_Proto\ProtoModel
echo.
echo =================将cs拷贝到%CS_PATH%工程目录=================

copy *.cs %CS_PATH%\*.cs
del *.cs

pause
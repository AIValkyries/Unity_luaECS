set XLS_FILE_NAME=��Դ���ñ�
set SHEET_NAME=ResConfig

@echo off

cd ..

call aa_xls2cs %SHEET_NAME% %XLS_FILE_NAME%

pause
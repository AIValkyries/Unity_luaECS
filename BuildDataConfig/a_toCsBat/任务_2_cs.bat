set XLS_FILE_NAME=����
set SHEET_NAME=TaskInfo

@echo off
cd ..

call aa_xls2cs %SHEET_NAME% %XLS_FILE_NAME%

pause
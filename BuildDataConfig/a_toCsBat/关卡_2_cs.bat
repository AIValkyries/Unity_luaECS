set XLS_FILE_NAME=�ؿ�
set SHEET_NAME=LevelConfig

@echo off

cd ..

call aa_xls2cs %SHEET_NAME% %XLS_FILE_NAME%

pause
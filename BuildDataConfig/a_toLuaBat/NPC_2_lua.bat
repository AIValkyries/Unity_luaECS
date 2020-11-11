set XLS_FILE_NAME=NPC
set SHEET_NAME=NpcInfo

@echo off
cd ..

call aa_xls2lua %SHEET_NAME% %XLS_FILE_NAME%

pause
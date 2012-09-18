@echo off
for /R . %%d IN (.) DO (
	cd %~dp0
	cd %%d
	echo %%d
	del /Q *.pdb
	del /Q *.xml
	del /Q *.manifest
	del *vshost.exe
	del *vshost.exe.config	
        del F500Tool.log
)
cd %~dp0
@echo off
rem For information see
rem https://search.thawte.com/support/ssl-digital-certificates/index?page=content&actp=CROSSLINK&id=SO17631

setlocal EnableExtensions EnableDelayedExpansion

set certificatesFolder=%~dp0

set target=%~1

if not exist "%target%" (
	echo First argument should be the name of the file, the one specified was not found.
	exit /b 1
)
shift

set description=%~1
if "%description%"=="" (
	echo Second argument should be the description the file is signed with.
	exit /b 1
)
shift

set signToolRelative1=Windows Kits\10\App Certification Kit\signtool.exe
set signtoolRelative2=Microsoft SDKs\ClickOnce\SignTool
set signtool="%ProgramFiles%\%signToolRelative1%"

rem RFC3161 timestamping URL for SHA256
set timestampURL256=http://timestamp.sectigo.com



if not exist %signtool% set signtool="%SystemDrive%\Progra~2\%signToolRelative1%"
if not exist %signtool% set signtool="%ProgramFiles%\%signToolRelative2%"
if not exist %signtool% set signtool="%SystemDrive%\Progra~2\%signToolRelative2%"

if not exist %signtool% (
    echo Signing tool not found:
    echo %signtool%
	exit /b 1
)


echo Signing %target% with description "%description%"

set signSHA256=%signtool% sign /tr "%timestampURL256%" /td SHA256 /fd SHA256 /d "%description%" /v /a "%target%" 

:signSHA256
echo %signSHA256%
%signSHA256%
if %errorlevel% NEQ 0 exit /b %errorlevel%










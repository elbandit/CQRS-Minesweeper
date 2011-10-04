@echo off

SET DIR=%~d0%~p0%

SET database.name="TestRoundhousE"
SET sql.files.directory="%DIR%..\db\SQLServer\TestRoundhousE"
SET server.database="(local)"
SET repository.path="http://roundhouse.googlecode.com/svn"
SET version.file="_BuildInfo.xml"
SET version.xpath="//buildInfo/version"
SET environment=LOCAL

"%DIR%Console\rh.exe" /d=%database.name% /f=%sql.files.directory% /s=%server.database% /vf=%version.file% /vx=%version.xpath% /r=%repository.path% /env=%environment% /drop
"%DIR%Console\rh.exe" /d=%database.name% /f=%sql.files.directory% /s=%server.database% /vf=%version.file% /vx=%version.xpath% /r=%repository.path% /env=%environment% /t /simple

@echo off
cecho "#darkgreen Hello #green World \n #darkcyan Hello #cyan World \n"
cecho "#dg Hello #g World \n #dc Hello #c World \n"

cecho "#c ##dc Hello World"
cecho "#g ##dg Hello World"

:YES_NO_UNITTEST_END
    cecho "#?yesno #dc Do you like #c cecho #dc (Y)es (N)o ? "
    if ERRORLEVEL == 1 echo you said yes & goto YES_NO_UNITTEST_END
    echo you said no
:YES_NO_UNITTEST_END

cecho "#g cecho unit tests done"
pause

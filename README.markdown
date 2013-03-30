# cecho

## Overview
cecho, a colorized echo for batch file.
cecho is a command line tool to print lines with colors from a batch file.

![alt sample](https://github.com/fredericaltorres/cecho/blob/master/README.jpg "ReadMeImage")

## Syntax
The character # followed by the color name or color short name,
set the foreground color.

### With color names
cecho "#darkgreen Hello #green World \n #darkcyan Hello #cyan World \n"

### with short color names
cecho "#dg Hello #g World \n #dc Hello #c World \n"

### Background and foreground color
The character ## followed by the color name or color short name,
set the background color. Always set the foreground color and then
the background could.

cecho "#c ##dc Hello World"

### Yes No user input
cecho allow also to ask Yes/No question with colors

    cecho "#?yesno #dc do you like #c cecho #dc (Y)es (N)o ? \n"

### List of colors

    black     
    darkblue  db 
    darkgreen dg 
    darkcyan dc  
    darkred dr  
    darkmagenta dm
    darkyellow dy
    gray      
    darkgray dgray 
    blue b     
    green g     
    cyan c      
    red r      
    magenta m   
    yellow y   
    white w    

## .NET Framework
cecho is written in C# using .NET 3.5.

## Copyright
Copyright (c) 2013 Frederic Torres

## License
You may use cecho and source under the terms of the MIT License.
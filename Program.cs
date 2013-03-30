/*
 * cecho
 * color echo for batch file
 * (c) Torres Frederic 2012
 * Release under the MIT license
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEcho {

    class Program {

        const string ColorsDemo      = "#black black #darkblue darkblue #darkgreen darkgreen #darkcyan darkcyan #darkred darkred #darkmagenta darkmagenta #darkyellow darkyellow #gray gray #darkgray darkgray #blue blue #green green #cyan cyan #red red #magenta #magenta #yellow #yellow #white #white";
        const string ColorsDemoShort = "#db db #dg dg #dc dc #dred dred #dm dm #dy dy #g g #dg dg #b b #gray gray #c c #r r #m m #y y #w w";
        const string ColorsDemo2     = "#dg Hello #g World \n #dc Hello #c World \n ";

        static Dictionary<string, ConsoleColor> Colors = new Dictionary<string, ConsoleColor>() {

            { "db",          ConsoleColor.DarkBlue    },
            { "dg",          ConsoleColor.DarkGreen   },
            { "dc",          ConsoleColor.DarkCyan    },
            { "dred",        ConsoleColor.DarkRed     },
            { "dm",          ConsoleColor.DarkMagenta },
            { "dy",          ConsoleColor.DarkYellow  },
            { "dgray",       ConsoleColor.DarkGray    },
            { "b",           ConsoleColor.Blue        },
            { "g",           ConsoleColor.Green       },
            { "c",           ConsoleColor.Cyan        },
            { "r",           ConsoleColor.Red         },
            { "m",           ConsoleColor.Magenta     },
            { "y",           ConsoleColor.Yellow      },
            { "w",           ConsoleColor.White       },
            { "black",       ConsoleColor.Black       },
            { "darkblue",    ConsoleColor.DarkBlue    },
            { "darkgreen",   ConsoleColor.DarkGreen   },
            { "darkcyan",    ConsoleColor.DarkCyan    },
            { "darkred",     ConsoleColor.DarkRed     },
            { "darkmagenta", ConsoleColor.DarkMagenta },
            { "darkyellow",  ConsoleColor.DarkYellow  },
            { "gray",        ConsoleColor.Gray        },
            { "darkgray",    ConsoleColor.DarkGray    },
            { "blue",        ConsoleColor.Blue        },
            { "green",       ConsoleColor.Green       },
            { "cyan",        ConsoleColor.Cyan        },
            { "red",         ConsoleColor.Red         },
            { "magenta",     ConsoleColor.Magenta     },
            { "yellow",      ConsoleColor.Yellow      },
            { "white",       ConsoleColor.White       },
        };

        const string INPUT_COMMAND = "#?yesno";

        static bool cechoInput(string command) {

            var k   = String.Empty;
            command = command.TrimStart();
            if(command.StartsWith(INPUT_COMMAND)) {

                command = command.Substring(INPUT_COMMAND.Length).TrimStart();
                cechoWriteline(command, false);
                while(true) {
                    k = Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant();
                    Console.WriteLine(k);
                    if(k == "Y" || k == "N")
                        break;
                }                
                Environment.Exit(k == "Y" ? 1 : 0);
            }
            return false;
        }

        static void cechoWriteline(string value, bool crlfAtTheEnd = true) {

            if(cechoInput(value))
                return;

            var words = value.Split(' ');

            for(var i=0; i<words.Length; i++) {

                 var w = words[i];

                 if (w.StartsWith("##")) {

                    //Console.ResetColor();
                    var color = w.Substring(2).ToLower();
                    Console.BackgroundColor = Colors.ContainsKey(color) ? Colors[color] : ConsoleColor.Gray;
                }
                else if (w.StartsWith("#")) {

                    Console.ResetColor();
                    var color = w.Substring(1).ToLower();
                    Console.ForegroundColor = Colors.ContainsKey(color) ? Colors[color] : ConsoleColor.Gray;
                }
                else if (w == @"\n") {

                    Console.WriteLine("");
                }
                else {
                    Console.Write(w + (i<words.Length-1 ? " " : ""));
                }
            }
            if(crlfAtTheEnd)
                Console.WriteLine("");
            Console.ResetColor();
        }

        static void Main(string[] args) {

            if(args.Length == 0) {

                Console.WriteLine("cecho - Colored Echo Command");
                Console.WriteLine("Syntax:");
                Console.WriteLine(String.Format("   cecho \"{0}\"",ColorsDemo));
                cechoWriteline(ColorsDemo);
                Console.WriteLine("\n");
                Console.WriteLine(String.Format("   cecho \"{0}\"", ColorsDemoShort));
                cechoWriteline(ColorsDemoShort);
                Console.WriteLine("\n");
                Console.WriteLine(String.Format("   cecho \"{0}\"", ColorsDemo2));
                cechoWriteline(ColorsDemo2);
            }
            else
            {
                foreach(var a in args)
                    cechoWriteline(a);

                if(System.Environment.CommandLine.Contains("-pause"))
                    Console.ReadLine();
            }
        }
    }
}



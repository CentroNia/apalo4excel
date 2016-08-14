using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace PaloUtility
{
/// <summary>
/// Provides utility functions for palo and palo installer
/// </summary>
class Program
    {
    static int Main(string[] args)
        {

        if (args.Length < 1)
            {
            Console.WriteLine("No function specified.");
            return 1;
            }
        
        int RC = 1;
        string Function = args[0].ToLower();
        switch (Function)
            {

            /*---------------------------------------------------*/
            /*  Sets environment variable values in a data file  */
            /*---------------------------------------------------*/
            //
            //  Function:
            //
            //      Scans a text file for %variable% and replaces with the value of the 
            //      named environment variable.
            //
            //  Syntax:
            //      setenvfile filename logfile
            //
            //  Note:
            //      If "logfile" is present, any errors are written there
            //
            case "setenvfile":
                if (args.Length < 2)
                    {
                    Console.WriteLine("Too few arguments for setenvfile function.");
                    Console.WriteLine("Usage: PaloUtility setenvfile filename");
                    break;
                    }

                //Console.WriteLine("PaloUtility setenvfile {0}", args[1]);
                //Console.ReadLine();

                string inFile = args[1];
                string logFile = args.Length > 2 ? args[2] : null;
                try
                    {
                    string[] Lines = File.ReadAllLines(inFile);
                    StringBuilder bld = new System.Text.StringBuilder();
                    int updcnt = 0;
                    for (int i=0; i<Lines.Length; i++)
                        {
                        int at=0;
                        while (at<Lines[i].Length && (at=Lines[i].IndexOf('%', at)) >= 0)
                            {
                            int end = Lines[i].IndexOf('%', at+1);
                            string var = Lines[i].Substring(at+1,end-at-1);
                            string val = System.Environment.GetEnvironmentVariable(var);
                            if (string.IsNullOrEmpty(val)) 
                                {
                                at = end+1;
                                continue;
                                }
                            bld.Length = 0;
                            bld.Append(Lines[i].Substring(0,at));
                            bld.Append(val);
                            bld.Append(Lines[i].Substring(++end));
                            Lines[i] = bld.ToString();
                            updcnt++;
                            at += val.Length;
                            }
                        }
                    if (updcnt > 0) File.WriteAllLines(inFile, Lines);
                    }
                catch (Exception Ex)
                    {
                    Console.WriteLine(Ex.Message);
                    //Console.ReadLine();  
                    if (!string.IsNullOrEmpty(logFile))
                        {      
                        using (StreamWriter wrt = new StreamWriter(logFile))
                            {
                            wrt.WriteLine(Ex.Message);
                            }
                        }        
                    break;
                    }

            RC = 0;
            break;
            }

        return RC;
        }

    }
}

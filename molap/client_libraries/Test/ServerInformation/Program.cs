using System;
using System.IO;
using Jedox.Palo.Comm;

namespace ServerInformation
{
class Program
    {
    static void Main(string[] args)
        {    
        string Server = args.Length > 0 ? args[0] : "127.0.0.1";
        string Port = args.Length > 1 ? args[1] : "7777";
        string User = args.Length > 2 ? args[2] : "admin";
        string Pass = args.Length > 3 ? args[3] : "admin";

        Console.WriteLine(string.Format("Using Server {0} Port {1} User {2} Pass {3}", Server, Port, User, Pass));
        Console.WriteLine("Please press enter to start ...");
        Console.ReadLine();
                
        Connection c = null;
        StreamWriter f = new StreamWriter("ServerInfo.txt");
        try
            {            

            c = new Connection(Server, Port, User, Pass);
           
            ServerInfo si = c.ServerInformation();
            writeLine(f, string.Format("Server Version: {0}.{1}.{2}", si.MajorVersion, si.MinorVersion, si.BuildNumber));
            String[] Databases = c.RootListDatabases();

            foreach (string DB in Databases)
                {
                DatabaseInfo dbi = c.DatabaseInformation(DB);
                writeLine(f, string.Format("Database: {0} ID={1} Type={2} Status={3})", dbi.Name, dbi.id, dbi.Type, dbi.Status));
                        
                String[] Cubenames = c.DatabaseListCubes(DB);
                foreach (string CB in Cubenames)
                    {
                    CubeInfo cbi = c.CubeInformation(DB, CB);
                    writeLine(f, string.Format("  Cube: {0} ID={1}  Type={2} Status={3}", cbi.Name, cbi.id, cbi.Type, cbi.Status));
                    foreach (string DM in cbi.Dimensions)
                        writeLine(f, (string.Format("    {0}", DM)));
                    }

                string[] Dimensions = c.DatabaseListDimensions(DB);
                foreach (string DM in Dimensions)
                    {
                    DimensionInfoSimple dmi = c.DimensionInformationSimple(DB, DM);
                    writeLine(f, string.Format("  Dim {0}  ID={1} Type={2}, {3} Elements, Max. Depth = {4}, AttrCube = {5}", 
                                    dmi.Name, dmi.id, dmi.Type, dmi.NumberElements, dmi.MaximumDepth, "depricated"));
                    }
                }
            }
        catch (Exception ex)
            {
            Console.WriteLine(ex.Message);        
            }
        finally
            {
            if (c != null) c.Dispose();
            f.Flush();
            f.Close();
            f.Dispose();
            }
        Console.WriteLine("Please press enter to end...");
        Console.ReadLine();
        }

    static void writeLine(StreamWriter f, string Line)
        {
        f.WriteLine(Line);
        Console.WriteLine(Line);
        }
    }
}

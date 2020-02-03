using System;
using System.Collections.Generic;
using System.IO;

namespace Blaze.JS
{
    class Program
    {
        static void Main(string[] args)
        {
            JSDocAnalyzer analyzer = new JSDocAnalyzer();
            List<JSDocAnalyzer.JSDoc> docs = new List<JSDocAnalyzer.JSDoc>();

            if(args.Length>0)
            {
                docs=analyzer.Analyse(args[0]);
            }
            else
            {
                string root=AppDomain.CurrentDomain.BaseDirectory;
                root=Path.Combine(root, "dir");
                if(!Directory.Exists(root))
                    Directory.CreateDirectory("dir");
                docs=analyzer.Analyse(root);
            }

            foreach (var item in docs)
            {
                foreach(var p in item.Properties)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(p.DataTypes);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  "+p.Name+";");
                }
                foreach (var func in item.Functions)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (func.ReturnTypes.Count > 0)
                        Console.Write(func.ReturnTypes[0] + "  ");
                    else
                        Console.Write("void  ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(func.FuncName);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write('(');
                    for (int i = 0; i < func.Parameters.Count; i++)
                    {
                        if (i != func.Parameters.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(func.Parameters[i].Name);
                            Console.Write(":");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(func.Parameters[i].ParameterTypes[0] + ",");
                        }
                        else if (i == func.Parameters.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(func.Parameters[i].Name);
                            Console.Write(":");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(func.Parameters[i].ParameterTypes[0]);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(")");
                        }
                    }
                    if(func.Parameters.Count==0)
                    {
                        Console.Write(")");
                    }
                    Console.WriteLine(";");

                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

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
                docs=analyzer.Analyse(@"C:\Users\shive\Desktop\Test\Blaze.JS\Blaze.JS\bin\Debug\netcoreapp3.1\");
            }

            foreach (var item in docs)
            {
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
                            Console.WriteLine(")");
                        }
                    }
                    if(func.Parameters.Count==0)
                    {
                        Console.WriteLine(");");
                    }

                }
            }
        }
    }
}

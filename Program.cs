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
            List<JSDoc> docs = new List<JSDoc>();

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

            GeneratorCSharp gen = new GeneratorCSharp();
            gen.BuildCSharpPage(docs.ToArray());
            GenerateJS genJs = new GenerateJS();
            genJs.BuildJS(docs.ToArray());

            foreach (var item in docs)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.FilePath);

                foreach(var p in item.Properties)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(p.DataTypes);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  "+p.Name+";");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("func");
                foreach (var func in item.Functions)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (func.ReturnTypes.Count > 0)
                        Console.Write(JSDocHelper.GetCSharpType(func.ReturnTypes[0].ToLower()) + "  ");
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
                            Console.Write(JSDocHelper.GetCSharpType(func.Parameters[i].ParameterTypes[0].ToLower()) + ",");
                        }
                        else if (i == func.Parameters.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(func.Parameters[i].Name);
                            Console.Write(":");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(JSDocHelper.GetCSharpType(func.Parameters[i].ParameterTypes[0].ToLower()));
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

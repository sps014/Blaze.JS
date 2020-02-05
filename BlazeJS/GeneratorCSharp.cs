using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blaze.JS
{
    public class GeneratorCSharp
    {
        public const string Namespace= "using System;\nusing System.Collections.Generic;\n\nnamespace Blaze.Gen\n{";
        public const string Closing = "}";
        public void BuildCSharpPage(JSDoc[] docs)
        {
            foreach(JSDoc doc in docs)
            {
                ProcessPage(doc);
            }
        }
        private string FileName (string jsName)
        {
            string root=jsName.Substring(0, jsName.LastIndexOf('.'));

            return root+".gen.cs";
        }
        private void ProcessPage(JSDoc doc)
        {
            StreamWriter writer = new StreamWriter(FileName(doc.FilePath));
            writer.WriteLine(Namespace);
            CreateProperty(doc, writer);
            writer.Write("\n");
            CreateFunctions(doc,writer);
            writer.WriteLine(Closing);
            writer.Close();
        }
        private void CreateProperty(JSDoc doc,StreamWriter writer)
        {
            foreach (var prop in doc.Properties)
            {
                writer.WriteLine("\t"+prop.DataTypes.ToLower().PadRight(10) +" "+ prop.Name+";");
            }
        }
        private void CreateFunctions(JSDoc doc, StreamWriter writer)
        {
            foreach (var func in doc.Functions)
            {
                if (func.ReturnTypes.Count > 0)
                    writer.Write("\t"+func.ReturnTypes[0] + "  ");
                else
                    writer.Write("\tvoid ");
                writer.Write(func.FuncName);
                writer.Write('(');
                for (int i = 0; i < func.Parameters.Count; i++)
                {
                    if (i != func.Parameters.Count - 1)
                    {
                        writer.Write(func.Parameters[i].ParameterTypes[0].ToLower() + " ");
                        writer.Write(func.Parameters[i].Name+",");

                    }
                    else if (i == func.Parameters.Count - 1)
                    {
                        writer.Write(func.Parameters[i].ParameterTypes[0].ToLower() + " ");
                        writer.Write(func.Parameters[i].Name + ")");
                    }
                }
                if (func.Parameters.Count == 0)
                {
                    writer.Write(")");
                }
                writer.WriteLine(";");

            }

        }
    }
}

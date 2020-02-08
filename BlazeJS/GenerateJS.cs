using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blaze.JS
{
    public class GenerateJS
    {
        public const string Closing = "\t}\n}";
        const string EOL = "\n";
        const string TAB = "\t";

        private string GenerateStart(JSDoc doc)
        {
            string mod = GetModuleName(doc);

            StringBuilder builder = new StringBuilder("");
            builder.Append("using System;" + EOL);
            builder.Append("using Microsoft.JSInterop;" + EOL);
            builder.Append("using System.Collections.Generic;" + EOL);
            builder.Append("namespace Test" + EOL);
            builder.Append("{" + EOL);
            builder.Append(TAB + "public class " + mod + EOL);

            builder.Append(TAB + "{" + EOL);
            builder.Append(TAB + TAB + "public IJSRuntime Runtime { get; set; }" + EOL + EOL);
            builder.Append(TAB + TAB + "public " + mod + "(IJSRuntime runtime)" + EOL);
            builder.Append(TAB + TAB + "{" + EOL);
            builder.Append(TAB + TAB + TAB + "Runtime=runtime;" + EOL);
            builder.Append(TAB + TAB + "}");

            return builder.ToString();

        }
        public void BuildJS(JSDoc[] docs)
        {
            foreach (JSDoc doc in docs)
            {
                ProcessPage(doc);
            }
        }
        private string FileName(string jsName)
        {
            string root = jsName.Substring(0, jsName.LastIndexOf('.'));

            return root + ".gen.js";
        }
        private void ProcessPage(JSDoc doc)
        {
            StreamWriter writer = new StreamWriter(FileName(doc.FilePath));
            //writer.WriteLine(GenerateStart(doc));
            //CreateProperty(doc, writer);
            CreateFunctions(doc, writer);
            writer.Close();
        }
        private void CreateProperty(JSDoc doc, StreamWriter writer)
        {
            foreach (var prop in doc.Properties)
            {
                writer.WriteLine("\t\t" + JSDocHelper.GetCSharpType(prop.DataTypes).PadRight(10) + " " + prop.Name + ";");
            }
        }
        private string GetModuleName(JSDoc doc)
        {
            string mod = doc.ModuleName;
            if (mod == null)
                return "TestClass";

            if (mod.Length <= 0)
                mod = "TestClass";

            return mod;

        }
        private void CreateFunctions(JSDoc doc, StreamWriter writer)
        {
            foreach (var func in doc.Functions)
            {
                if (func.ReturnTypes.Count == 0)
                {
                    writer.Write(voidFunction(func, GetModuleName(doc)));
                }
                else
                {
                    writer.Write(nonVoidFunction(func, GetModuleName(doc)));
                }
            }

        }
        private string voidFunction(Function func, string modName)
        {
            StringBuilder builder = new StringBuilder("");
            builder.Append("function " + modName+ '_'+func.FuncName + "(");
            string prms = "";
            for (int i = 0; i < func.Parameters.Count; i++)
            {
                builder.Append(" " + func.Parameters[i].Name);
                prms += func.Parameters[i].Name;
                if (i != func.Parameters.Count - 1)
                {
                    builder.Append(",");
                    prms += ",";
                }
            }
            builder.Append(")" + EOL);
            builder.Append("{" + EOL);
            builder.Append(TAB + func.FuncName+"(");
            builder.Append(prms + ");" + EOL);
            builder.Append("}" + EOL);
 

            return builder.ToString();
        }
        private string nonVoidFunction(Function func, string modName)
        {
            StringBuilder builder = new StringBuilder("");
            builder.Append("function " + modName + '_' + func.FuncName + "(");
            string prms = "";
            for (int i = 0; i < func.Parameters.Count; i++)
            {
                builder.Append(" " + func.Parameters[i].Name);
                prms += func.Parameters[i].Name;
                if (i != func.Parameters.Count - 1)
                {
                    builder.Append(",");
                    prms += ",";
                }
            }
            builder.Append(")" + EOL);
            builder.Append("{" + EOL);
            builder.Append(TAB + "return "+func.FuncName + "(");
            builder.Append(prms + ");" + EOL);
            builder.Append("}" + EOL);


            return builder.ToString();
        }

    }
}

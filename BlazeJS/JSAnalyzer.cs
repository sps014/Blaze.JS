using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Blaze.JS
{
    public class JSDocAnalyzer
    {
        private const string OpeningTag = "/**";
        private const string ClosingTag = "*/";
        public List<JSDoc> Analyse(string dir)
        {
            List<JSDoc> docs = new List<JSDoc>();
            string[] files=Directory.GetFiles(dir);
            foreach (string file in files)
            {
                if(new FileInfo(file).Extension.ToLower()==".js")
                {
                    docs.Add(ReadFile(file));
                }
            }
            return docs;
        }
        private JSDoc ReadFile(string file)
        {
            JSDoc docFile = new JSDoc();

            List<Function> funcList = new List<Function>();
            List<Property> propList = new List<Property>();

            //extract comments from file
            StreamReader reader = new StreamReader(file);
            string text=reader.ReadToEnd();
            reader.Close();
            string[] data=ParseContent(text);

            ///parse each comment to get functions info
            foreach (string d in data)
            {
                Function func=ParseFunctions(d);
                if (!string.IsNullOrWhiteSpace(func.FuncName))
                    funcList.Add(func);

                //add prop
                Property p = ParseProperty(d);
                if (!string.IsNullOrWhiteSpace(p.Name))
                    propList.Add(p);

            }

            docFile.Functions = funcList;
            docFile.FilePath = file;
            docFile.Properties = propList;
            return docFile;
        }
        private Property ParseProperty(string func)
        {
            Property prop = new Property();

            string[] lines = func.Split("\r\n");
            foreach (string line in lines)
            {
                if (line.IndexOf("@") < 0)
                {
                    continue;
                }
                else
                {
                   
                    if (line.IndexOf("@property") >= 0)
                    {
                        var p =GetParam(line,"@property");
                        prop.Name = p.Name;
                        prop.DataTypes = p.ParameterTypes.FirstOrDefault();
                    }
                    else if (line.IndexOf("@example") >= 0)
                    {
                        break;
                    }
                }

            }
            return prop;
        }

        private Function ParseFunctions(string func)
        {
            Function fun = new Function();

            string[] lines = func.Split("\r\n");
            foreach(string line in lines)
            {
                if(line.IndexOf("@")<0)
                {
                    continue;
                }
                else
                {
                    if (line.IndexOf("@method") >= 0)
                    {
                        fun.FuncName=GetFunctionName(line);
                    }
                    else if(line.IndexOf("@param")>=0)
                    {
                        fun.Parameters.Add(GetParam(line));
                    }
                    else if (line.IndexOf("@return") >= 0)
                    {
                        fun.ReturnTypes=GetReturn(line);
                    }
                    else if (line.IndexOf("@type") >= 0)
                    {
                        fun.ReturnTypes = GetReturn(line,"@type");
                    }
                    else if(line.IndexOf("@private") >= 0)
                    {
                        fun.Private = true;
                    }
                    else if (line.IndexOf("@async") >= 0)
                    {
                        fun.Async = true;
                    }
                    else if (line.IndexOf("@static") >= 0)
                    {
                        fun.Static = true;
                    }
                    else if (line.IndexOf("@example") >= 0)
                    {
                        break;
                    }
                }
                
            }
            return fun;
        }
        string GetFunctionName(string function,string name="@method")
        {
            int ind=function.IndexOf(name) + name.Length+1;
            while (function[ind] == ' ')
                ind++;
            int last = function.IndexOf(" ", ind+1);
            if (last < 0)
                return function.Substring(ind).Replace("\n","");
            else
                return function.Substring(ind, last - ind).Replace("\n","");
        }
        Parameter GetParam(string func,string tag="@param")
        {


            int ind = func.IndexOf(tag) + tag.Length + 1;
            func=func.Substring(ind);

            string pTypes;
            try {
                pTypes = func.Split('{', '}')[1];
            }
            catch (Exception) { pTypes = "Any"; }

            //get param name
            func = func.Substring(func.IndexOf('}') + 1);
            string[] names = func.Split();
            string name = "";

            foreach (string item in names)
            {
                if(!string.IsNullOrWhiteSpace(item))
                {
                    name = item;
                    break;
                }
            }
            //handle param types
            string[] types = pTypes.Split(new char[] { '|' ,' ','\n'});

            //check if optional param
            bool optional = false;
            for(int i= 0;i< types.Length;i++)
            {
                if (types[i].IndexOf('=') >= 0)
                {
                    optional = true;
                    types[i] = types[i].Replace("=", "");
                }
            }
            if (name.IndexOf('[') >= 0 && name.IndexOf(']') > 0)
            {
                optional = true;
                name = name.Replace("[", "");
                name = name.Replace("]", "");

            }
            Parameter parameter = new Parameter();
            parameter.Name = name;
            parameter.Optional = optional;
            parameter.ParameterTypes.AddRange(types);

            return parameter;

        }
        List<string> GetReturn(string func, string tag = "@return")
        {

            int ind = func.IndexOf(tag) + tag.Length + 1;
            func = func.Substring(ind);
            string pTypes = func.Split('{', '}')[1];

            //get param name
            func = func.Substring(func.IndexOf('}') + 1);
 
            //handle param types
            string[] types = pTypes.Split('|');
            var list=new List<string>();
            list.AddRange(types);
            return list ;

        }

        private string[] ParseContent(string text)
        {
            List<string> Blocks = new List<string>();
            int firstIndex=0,closingIndex=0;
            while((firstIndex=text.IndexOf(OpeningTag,firstIndex))>=0)
            {
                closingIndex = text.IndexOf(ClosingTag, firstIndex + 1);
                if(closingIndex>0)
                {
                    Blocks.Add(text.Substring(firstIndex,closingIndex-firstIndex+2));
                }
                else
                {
                    break;
                }


                closingIndex++;
                firstIndex++;
            }
            return Blocks.ToArray();

        }

        public delegate void OnFinishedHandler(object sender,ResultArgs resultArgs);
        public event OnFinishedHandler OnFinished;

       

        public class ResultArgs
        {
            public Result Result { get; set; }
        }
        public enum Result
        {
            Failed,
            Successful
        }
    }
}

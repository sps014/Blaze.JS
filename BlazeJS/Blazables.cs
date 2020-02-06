using System;
using System.Collections.Generic;
using System.Text;

namespace Blaze.JS
{
    public class JSDoc
    {
        public string FilePath { get; set; } = "";
        public List<Function> Functions { get; set; } = new List<Function>();
        public List<Property> Properties { get; set; }
        public string ModuleName { get; set; }
    }
    public class Function
    {
        public string FuncName { get; set; } = "";
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
        public List<string> ReturnTypes { get; set; } = new List<string>();
        public bool Private { get; set; } = false;
        public bool Async { get; set; } = false;
        public bool Static { get; set; } = false;


    }
    public class Parameter
    {
        public bool Optional { get; set; } = false;
        public string Name { get; set; } = "";

        public List<string> ParameterTypes { get; set; } = new List<string>();

    }
    public class Property
    {
        public string Name { get; set; } = "";
        public string DataTypes { get; set; } = "";
    }
}

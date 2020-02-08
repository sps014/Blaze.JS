using System;
using System.Collections.Generic;
using System.Text;

namespace Blaze.JS
{
    public static class JSDocHelper
    {
        public static Dictionary<string, string> CSharpMap
        {
            get
            {
                Dictionary<string, string> map = new Dictionary<string, string>();
                 /*
                 null
                 undefined
                 boolean
                 number
                 string
                 or []
                 Object or {}
                 */
                //map.Add("null", "null");
                map.Add("undefined", "null");
                map.Add("boolean", "bool");
                map.Add("Boolean", "bool");
                map.Add("Number", "double");
                map.Add("number", "double");
                map.Add("any", "object");
                map.Add("Any", "object");

                ///map.Add("string", "string");

                return map;
            }
        }
        public static string GetCSharpType(string type)
        {
            if (type == null)
                return "object";

            if (CSharpMap.ContainsKey(type))
                return CSharpMap[type];
            else
                return type;
        }
        public static List<string> JSDocTags
        {
            get
            {
                List<string> tags = new List<string>();
                tags.Add("@param");
                tags.Add("@method");
                tags.Add("@return");
                tags.Add("@type");
                return tags;
            }
        }
    }
}

﻿using System;
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
                map.Add("null", "null");
                map.Add("undefined", "null");
                map.Add("boolean", "bool");
                map.Add("number", "double");
                map.Add("string", "string");

                return map;
            }
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

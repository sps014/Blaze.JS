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
            string root=Path.GetPathRoot(jsName);

            return root;
        }
        private void ProcessPage(JSDoc doc)
        {
            FileName(doc.FilePath);
            //StreamWriter writer=new StreamWriter()
        }
        private void CreateProperty()
        {

        }
    }
}

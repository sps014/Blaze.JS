using System;
using System.Collections.Generic;
using System.Text;

namespace Blaze.JS
{
    public class GeneratorCSharp
    {
        public void BuildCSharpPage(JSDoc[] docs)
        {
            foreach(JSDoc doc in docs)
            {
                ProcessPage(doc);
            }
        }
        private void ProcessPage(JSDoc doc)
        {

        }
    }
}

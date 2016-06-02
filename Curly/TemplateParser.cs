using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curly
{
    public class TemplateParser
    {
        private readonly string _templateString;
        private int _index = 0;

        public TemplateParser(string templateString)
        {
            _templateString = templateString;
        }

        public Template Parse()
        {
            var template = new Template();
            var content = new StringBuilder();

            while (_index < _templateString.Length)
            {
                var curr = _templateString[_index];

                if (curr == '{')
                {
                    _index++;

                    curr = _templateString[_index];
                    if (curr == '{')
                    {
                        template.AddStringBlock(content.ToString());
                        content.Clear();
                        template.AddBlock(ParseBlock());
                    }
                    else
                    {
                        content.Append(curr);
                    }
                }
                else
                {
                    content.Append(curr);
                }
                _index++;
            }
            if (content.Length > 0)
            {
                template.AddStringBlock(content.ToString());
            }

            return template;
        }

        private Template ParseBlock()
        {
            return null;
        }
    }
}

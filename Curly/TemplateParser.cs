using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curly.Blocks;

namespace Curly
{
    public class TemplateParser
    {
        private readonly string _templateString;
        private int _index = 0;

        public static Template Parse(string templateString)
        {
            return new TemplateParser(templateString).Parse();
        }

        private TemplateParser(string templateString)
        {
            _templateString = templateString;
        }

        private Template Parse()
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
                        template.AddBlock(new StringBlock(content.ToString()));
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
                template.AddBlock(new StringBlock(content.ToString()));
            }

            return template;
        }

        private IBlock ParseBlock()
        {
            _index++;

            switch (_templateString[_index])
            {
                case '=': 
                    return ParseInterpolation();
                case '?': throw new NotImplementedException("No evaluation"); // evaluation
                case '@': throw new NotImplementedException(); // iteration
                default:
                    throw new UnexpectedSymbolException(_index, _templateString, UnexpectedSymbolException.ExpectedBlockStarter);
            }
        }

        private InterpolationBlock ParseInterpolation()
        {
            _index++;
            while (_templateString[_index] == ' ') _index++;

            var fullIdentifier = new List<string>(3);
            var currIndentifier = new StringBuilder();
            var curr = _templateString[_index];
            while (curr != '{' && curr != ' ')
            {
                if (curr == '.')
                {
                    fullIdentifier.Add(currIndentifier.ToString());
                    currIndentifier.Clear();
                }
                else
                {
                    currIndentifier.Append(curr);
                }
                
                _index++;
                curr = _templateString[_index];
            }
            fullIdentifier.Add(currIndentifier.ToString());

            // Todo: Optimize finding the closing }} of a block
            while (_templateString[_index] == ' ') _index++;
            if (_templateString[_index] != '}' || _templateString[++_index] != '}')
            {
                throw new UnexpectedSymbolException(_index, _templateString, UnexpectedSymbolException.ClosingBlock);
            }

            return new InterpolationBlock(fullIdentifier);
        }
    }
}

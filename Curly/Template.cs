using System.Collections.Generic;
using System.Text;
using Curly.Blocks;

namespace Curly
{
    public class Template
    {
        private readonly List<IBlock> _blocks = new List<IBlock>();

        internal void AddStringBlock(string content)
        {
            _blocks.Add(new StringBlock(content));
        }

        internal void AddBlock(object parseBlock)
        {
            
        }

        public string Execute(object data)
        {
            var buffer = new StringBuilder();
            foreach (var block in _blocks)
            {
                block.Execute(buffer, data);
            }
            return buffer.ToString();
        }
    }
}
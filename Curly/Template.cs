using System.Collections.Generic;
using System.Text;
using Curly.Blocks;

namespace Curly
{
    public class Template
    {
        private readonly List<IBlock> _blocks = new List<IBlock>();
        
        internal void AddBlock(IBlock block)
        {
            _blocks.Add(block);
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
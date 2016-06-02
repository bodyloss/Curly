using System.Text;

namespace Curly.Blocks
{
    public class StringBlock : IBlock
    {
        private readonly string _content;

        public StringBlock(string content)
        {
            _content = content;
        }

        public void Execute(StringBuilder buffer, object data)
        {
            buffer.Append(_content);
        }
    }
}
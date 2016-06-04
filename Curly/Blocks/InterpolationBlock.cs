using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Curly.Blocks
{
    public class InterpolationBlock : IBlock
    {
        private readonly IEnumerable<string> _identifier;


        public InterpolationBlock(IEnumerable<string> identifier)
        {
            _identifier = identifier;
            if (identifier.First() != "c")
            {
                throw new ArgumentException("All interpolation is based off the global object c, ensure all identifiers are of the form c.x.y.z. Offending identifier is " + string.Join(".", identifier));
            }
        }

        public void Execute(StringBuilder buffer, object data)
        {
            object currentObject = data;

            foreach (var property in _identifier.Skip(1))
            {
                currentObject = currentObject.GetType().GetProperty(property).GetValue(currentObject);
            }

            buffer.Append(currentObject);
        }
    }
}
using System;

namespace Curly
{
    internal class UnexpectedSymbolException : Exception
    {
        internal static char[] ExpectedBlockStarter = { '=', '?', '@'};

        internal static string CreateErrorMessage(int index, string templateString, char[] expected)
        {
            return string.Format("There was an unexpected symbol '{0}' at col {1}. Expected one of [{2}].", templateString[index], index, string.Join(",", expected));
        }

        public UnexpectedSymbolException(int index, string templateString, char[] expectedSymbols)
            : base(CreateErrorMessage(index, templateString, expectedSymbols))
        {
        }
    }
}
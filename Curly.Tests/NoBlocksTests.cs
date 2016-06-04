using System;
using NUnit.Framework;

namespace Curly.Tests
{
    [TestFixture]
    public class NoBlocksTests
    {
        [Test]
        public void ParsesAndExecutesStringTemplateWithNoBlocks()
        {
            // Act
            var template = "This is my template";

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(null);

            // Assert
            Assert.That(rendered, Is.EqualTo(template));
        }

        [Test]
        public void ParsesAndExecutesStringTemplateWithEmptyBlock()
        {
            // Act
            var template = "This is my{{}} template";

            // Act
            Assert.Throws<UnexpectedSymbolException>(() => TemplateParser.Parse(template));
        }
    }
}

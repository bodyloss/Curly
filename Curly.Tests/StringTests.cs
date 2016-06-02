using NUnit.Framework;

namespace Curly.Tests
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void ParsesAndExecutesStringTemplateWithNoBlocks()
        {
            // Act
            var template = "This is my template";

            // Act
            var parsedTemplate = new TemplateParser(template).Parse();
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
            var parsedTemplate = new TemplateParser(template).Parse();
            var rendered = parsedTemplate.Execute(null);

            // Assert
            Assert.That(rendered, Is.EqualTo("This is my template"));
        }
    }
}

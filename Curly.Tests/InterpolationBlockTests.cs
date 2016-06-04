using NUnit.Framework;

namespace Curly.Tests
{
    [TestFixture]
    public class InterpolationBlockTests
    {
        [Test]
        public void WritesAnonymousInteger()
        {
            // Act
            var template = "My value is: {{= c.Value }}";

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(new {Value = 123});

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: 123"));
        }

        [Test]
        public void WritesAnonymousString()
        {
            // Act
            var template = "My value is: {{= c.Value }}";

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(new { Value = "123" });

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: 123"));
        }

        [Test]
        public void WritesAnonymousBool()
        {
            // Act
            var template = "My value is: {{= c.Value }}";

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(new { Value = true });

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: True"));
        }

        [Test]
        public void WritesAnonymousDouble()
        {
            // Act
            var template = "My value is: {{= c.Value }}";

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(new { Value = 1.23d });

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: 1.23"));
        }


        [Test]
        public void WritesStronglyTypedInteger()
        {
            // Act
            var template = "My value is: {{= c.Value }}";
            var strongType = new StrongType<int>()
            {
                Value = 123
            };

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(strongType);

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: 123"));
        }

        [Test]
        public void WritesStronglyTypedString()
        {
            // Act
            var template = "My value is: {{= c.Value }}";
            var strongType = new StrongType<string>()
            {
                Value = "123"
            };

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(strongType);

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: 123"));
        }

        [Test]
        public void WritesStronglyTypedBoolean()
        {
            // Act
            var template = "My value is: {{= c.Value }}";
            var strongType = new StrongType<bool>()
            {
                Value = true
            };

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(strongType);

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: True"));
        }

        [Test]
        public void WritesStronglyTypedDouble()
        {
            // Act
            var template = "My value is: {{= c.Value }}";
            var strongType = new StrongType<double>()
            {
                Value = 1.23d
            };

            // Act
            var parsedTemplate = TemplateParser.Parse(template);
            var rendered = parsedTemplate.Execute(strongType);

            // Assert
            Assert.That(rendered, Is.EqualTo("My value is: 1.23"));
        }

        private class StrongType<T>
        {
            public T Value { get; set; }
        }
    }
}

using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests.RomanNumbers
{
    class When_creating
    {
        [Test]
        public void Should_uppercase_the_string_representation()
        {
            //arrange
            var inputStringRepresentation = "mcM";
            var expectedStringRepresentation = "MCM";

            //act
            var actualStringRepresentation = RomanNumber.Parse(inputStringRepresentation).StringRepresentation;

            //assert
            Assert.That(actualStringRepresentation, Is.EqualTo(expectedStringRepresentation),
                "Input string representation: " + inputStringRepresentation);
        }

        [Test]
        [SetCulture("tr-TR")]
        public void Should_uppercase_the_string_representation_under_turkey_test()
        {
            //arrange
            var inputStringRepresentation = "iI";
            var expectedStringRepresentation = "II";

            //act
            var actualStringRepresentation = RomanNumber.Parse(inputStringRepresentation).StringRepresentation;

            //assert
            Assert.That(actualStringRepresentation, Is.EqualTo(expectedStringRepresentation),
                        "Input string representation: " + inputStringRepresentation);
        }
    }
}

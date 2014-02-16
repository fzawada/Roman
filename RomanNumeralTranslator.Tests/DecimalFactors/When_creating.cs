using System;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests.DecimalFactors
{
    [TestFixture]
    class When_creating
    {
        [Test]
        [TestCase(1, 1, 0)]
        [TestCase(9, 9, 0)]
        [TestCase(10, 1, 1)]
        [TestCase(30, 3, 1)]
        [TestCase(100, 1, 2)]
        [TestCase(600, 6, 2)]
        [TestCase(2000, 2, 3)]
        [TestCase(-1, 0, 0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0, 0, 0, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(12, 0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(110, 0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(2001, 0, 0, ExpectedException = typeof(ArgumentException))]
        public void Case(int decimalFactorAsInteger, int expectedMultiplier, int expectedExponent)
        {
            //act
            var actualDecimalFactor = new DecimalFactor(decimalFactorAsInteger);

            //assert
            var expectedDecimalFactor = new DecimalFactor(expectedMultiplier, expectedExponent);
            Assert.That(actualDecimalFactor, Is.EqualTo(expectedDecimalFactor),
                "Decimal factor as integer: " + decimalFactorAsInteger);
        }
    }
}

using NUnit.Framework;

namespace RomanNumeralTranslator.Tests.RomanNumeralSymbols
{
    [TestFixture]
    class When_getting_base_unit_for_exponent
    {
        [Test]
        [TestCase(0, "I")]
        [TestCase(1, "X")]
        [TestCase(2, "C")]
        [TestCase(3, "M")]
        public void Case(int exponent, string expectedSymbol)
        {
            //act
            var actualSymbol = RomanNumeralSymbol.BaseUnitForExponent(exponent);

            //assert
            Assert.AreEqual(expectedSymbol, actualSymbol, "Input exponent: " + exponent);
        }
    }
}

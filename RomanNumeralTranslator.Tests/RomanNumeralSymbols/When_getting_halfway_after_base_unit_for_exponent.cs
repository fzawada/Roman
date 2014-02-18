using NUnit.Framework;

namespace RomanNumeralTranslator.Tests.RomanNumeralSymbols
{
    [TestFixture]
    class When_getting_halfway_after_base_unit_for_exponent
    {
        [Test]
        [TestCase(0, 'V')]
        [TestCase(1, 'L')]
        [TestCase(2, 'D')]
        public void Case(int exponent, char expectedSymbolString)
        {
            //arrange
            var expectedSymbol = (RomanNumeralSymbol) expectedSymbolString;

            //act
            var actualSymbol = RomanNumeralSymbol.HalfwayAfterBaseUnitForExponent(exponent);

            //assert
            Assert.AreEqual(expectedSymbol, actualSymbol, "Input exponent: " + exponent);
        }
    }
}

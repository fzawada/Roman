using System;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests
{
    class When_translating_single_decimal_factor_to_roman_part
    {
        [Test]
        [TestCase(6, "VI")]
        [TestCase(10, "X")]
        [TestCase(20, "XX")]
        [TestCase(30, "XXX")]
        [TestCase(40, "XL")]
        [TestCase(50, "L")]
        [TestCase(60, "LX")]
        [TestCase(70, "LXX")]
        [TestCase(80, "LXXX")]
        [TestCase(90, "XC")]
        [TestCase(100, "C")]
        [TestCase(900, "CM")]
        [TestCase(2000, "MM")]
        public void Case(int decimalFactorInteger, string expectedRomanPart)
        {
            //arrange
            var decimalFactor = new DecimalFactor(decimalFactorInteger);

            //act
            var actualRomanPart = DecimalFactorToRomanPartTranslator.Translate(decimalFactor);

            //assert
            Assert.AreEqual(
                expectedRomanPart,
                actualRomanPart,
                string.Format(
                    "Input decimal factor integer: {0}. {1}{2}  Roman ",
                    decimalFactorInteger,
                    Environment.NewLine,
                    Environment.NewLine
                ));
        }
    }
}

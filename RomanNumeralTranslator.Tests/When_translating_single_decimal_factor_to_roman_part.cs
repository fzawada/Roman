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


        public class DecimalFactorToRomanPartTranslator
        {
            public static string Translate(DecimalFactor decimalFactor)
            {
                var baseUnit = RomanNumeralSymbol.BaseUnitForExponent(decimalFactor.Exponent);
                string halfway = string.Empty;
                string nextBaseUnit = string.Empty;

                if (decimalFactor.Exponent < 3)
                {
                    halfway = RomanNumeralSymbol.HalfwayAfterBaseUnitForExponent(decimalFactor.Exponent);
                    nextBaseUnit = RomanNumeralSymbol.BaseUnitForExponent(decimalFactor.Exponent + 1);
                }

                var multiplier = decimalFactor.Multiplier;
                if (multiplier == 0)
                {
                    return string.Empty;
                }
                if (multiplier == 1)
                {
                    return baseUnit;
                }
                if (multiplier == 2)
                {
                    return baseUnit + baseUnit;
                }
                if (multiplier == 3)
                {
                    return baseUnit + baseUnit + baseUnit;
                }
                if (multiplier == 4)
                {
                    return baseUnit + halfway;
                }
                if (multiplier == 5)
                {
                    return halfway;
                }
                if (multiplier == 6)
                {
                    return halfway + baseUnit;
                }
                if (multiplier == 7)
                {
                    return halfway + baseUnit + baseUnit;
                }
                if (multiplier == 8)
                {
                    return halfway + baseUnit + baseUnit + baseUnit;
                }
                if (multiplier == 9)
                {
                    return baseUnit + nextBaseUnit;
                }

                throw new ArgumentException(
                    string.Format(
                        "Cannot translate decimal factor {0} to a roman part",
                        decimalFactor));
            }
        }
    }
}

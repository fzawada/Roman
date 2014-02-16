using System;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests
{
    class When_translating_single_decimal_factor_to_roman_part
    {
        [Test, Ignore("DecimalFactor and RomanNumeralSymbol implemenatation needed")]
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
            string actualRomanPart = DecimalFactorToRomanPartTranslator.Translate(decimalFactor);

            //assert
            Assert.AreSame(
                expectedRomanPart,
                actualRomanPart,
                string.Format(
                    "Input decimal factor integer: {0}. {1}{2}  Roman ",
                    decimalFactorInteger,
                    Environment.NewLine,
                    Environment.NewLine
                ));
        }

        public struct DecimalFactor
        {
            public DecimalFactor(int integer) : this()
            {
                //validate input
                //transform to multiplier and exponent
            }

            public int Multiplier { get; set; }
            public int Exponent { get; set; }
        }

        public struct RomanNumeralSymbol
        {
            public static RomanNumeralSymbol BaseUnitForExponent(int exponent)
            {
                return new RomanNumeralSymbol();
            }

            public static RomanNumeralSymbol HalfwayAfterBaseUnitForExponent(int exponent)
            {
                return new RomanNumeralSymbol();
            }
        }

        public class DecimalFactorToRomanPartTranslator
        {
            public static string Translate(DecimalFactor decimalFactor)
            {
                var baseUnit = RomanNumeralSymbol.BaseUnitForExponent(decimalFactor.Exponent);
                var halfway = RomanNumeralSymbol.HalfwayAfterBaseUnitForExponent(decimalFactor.Exponent);
                var nextBaseUnit = RomanNumeralSymbol.BaseUnitForExponent(decimalFactor.Exponent + 1);

                var multiplier = decimalFactor.Multiplier;
                if (multiplier == 0)
                {
                    return string.Empty;
                }
                if (multiplier == 1)
                {
                    return baseUnit.ToString();
                }
                if (multiplier == 2)
                {
                    return baseUnit.ToString() + baseUnit.ToString();
                }
                if (multiplier == 3)
                {
                    return baseUnit.ToString() + baseUnit.ToString() + baseUnit.ToString();
                }
                if (multiplier == 4)
                {
                    return baseUnit.ToString() + halfway.ToString();
                }
                if (multiplier == 5)
                {
                    return halfway.ToString();
                }
                if (multiplier == 6)
                {
                    return halfway.ToString() + baseUnit.ToString();
                }
                if (multiplier == 7)
                {
                    return halfway.ToString() + baseUnit.ToString() + baseUnit.ToString();
                }
                if (multiplier == 8)
                {
                    return halfway.ToString() + baseUnit.ToString() + baseUnit.ToString() + baseUnit.ToString();
                }
                if (multiplier == 9)
                {
                    return baseUnit.ToString() + nextBaseUnit.ToString();
                }

                throw new ArgumentException(
                    string.Format(
                        "Cannot translate decimal factor {0} to a roman part",
                        decimalFactor));
            }
        }
    }
}

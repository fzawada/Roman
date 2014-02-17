using System;

namespace RomanNumeralTranslator
{
    public class DecimalFactorToRomanPartTranslator
    {
        public static string Translate(DecimalFactor decimalFactor)
        {
            var baseUnit = RomanNumeralSymbol.BaseUnitForExponent(decimalFactor.Exponent);
            var halfway = string.Empty;
            var nextBaseUnit = string.Empty;

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

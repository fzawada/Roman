using System;

namespace RomanNumeralTranslator
{
    public struct RomanNumeralSymbol
    {
        public static string BaseUnitForExponent(int exponent)
        {
            if (exponent < 0 || exponent > 3)
            {
                throw new ArgumentOutOfRangeException("exponent", "Exponent has to be within [0..3] range");
            }

            if (exponent == 0)
            {
                return "I";
            }
            if (exponent == 1)
            {
                return "X";
            }
            if (exponent == 2)
            {
                return "C";
            }
            if (exponent == 3)
            {
                return "M";
            }

            throw new Exception("This part should be unreachable. exponent=" + exponent);
        }

        public static string HalfwayAfterBaseUnitForExponent(int exponent)
        {
            if (exponent < 0 || exponent > 2)
            {
                throw new ArgumentOutOfRangeException("exponent", "Exponent has to be within [0..2] range");
            }
            if (exponent == 0)
            {
                return "V";
            }
            if (exponent == 1)
            {
                return "L";
            }
            if (exponent == 2)
            {
                return "D";
            }

            throw new Exception("This part should be unreachable. exponent=" + exponent);
        }
    }
}

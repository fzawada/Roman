using System;

namespace RomanNumeralTranslator
{
    public struct RomanNumeralSymbol
    {
        public static readonly RomanNumeralSymbol I = new RomanNumeralSymbol('I', 1);
        public static readonly RomanNumeralSymbol V = new RomanNumeralSymbol('V', 5);
        public static readonly RomanNumeralSymbol X = new RomanNumeralSymbol('X', 10);
        public static readonly RomanNumeralSymbol L = new RomanNumeralSymbol('L', 50);
        public static readonly RomanNumeralSymbol C = new RomanNumeralSymbol('C', 100);
        public static readonly RomanNumeralSymbol D = new RomanNumeralSymbol('D', 500);
        public static readonly RomanNumeralSymbol M = new RomanNumeralSymbol('M', 1000);

        public static RomanNumeralSymbol[] All = new[] { I, V, X, L, C, D, M };

        private readonly char symbol;
        private readonly int value;

        public char Symbol { get { return symbol; } }
        public int Value { get { return value; } }

        private RomanNumeralSymbol(char symbol, int value)
        {
            this.symbol = symbol;
            this.value = value;
        }

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

        public override string ToString()
        {
            return symbol.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RomanNumeralSymbol))
            {
                return false;
            }

            var other = (RomanNumeralSymbol)obj;
            var areEqual = symbol == other.symbol &&
                           value == other.value;

            return areEqual;
        }

        public static bool operator ==(RomanNumeralSymbol s1, RomanNumeralSymbol s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(RomanNumeralSymbol s1, RomanNumeralSymbol s2)
        {
            return !(s1 == s2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 137;
                hash = hash * 31 + symbol.GetHashCode();
                hash = hash * 31 + value.GetHashCode();
                return hash;
            }
        }

    }
}

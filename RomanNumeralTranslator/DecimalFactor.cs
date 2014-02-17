using System;

namespace RomanNumeralTranslator
{
    public struct DecimalFactor : IEquatable<DecimalFactor>
    {
        public int Multiplier { get; private set; }
        public int Exponent { get; private set; }

        public DecimalFactor(int integer)
            : this()
        {
            if (integer < 1)
            {
                throw new ArgumentOutOfRangeException("integer",
                    "Decimal factor does not exist for numbers smaller than 1");
            }

            TransformAndAssignToMultiplierAndExponent(integer);
        }

        public DecimalFactor(int multiplier, int exponent)
            : this()
        {
            Multiplier = multiplier;
            Exponent = exponent;
        }

        private void TransformAndAssignToMultiplierAndExponent(int integer)
        {
            var exponent = 0;
            var currentInteger = integer;
            while (currentInteger%10 == 0)
            {
                currentInteger /= 10;
                exponent++;
            }
            if (currentInteger > 9)
            {
                throw new ArgumentException(
                    integer + " is not a correct decimal factor. Input argument has to be representable " +
                    "in this format: multiplier * 10^exponent, where both values are positive integers");
            }

            Multiplier = currentInteger;
            Exponent = exponent;
        }

        private static readonly string TypeName = typeof(DecimalFactor).Name;
        private string stringRepresentation;
        public override string ToString()
        {
            if (stringRepresentation == null)
            {
                stringRepresentation = string.Format(
                    @"{0} {{Multiplier={1}, Exponent={2}}}",
                    TypeName,
                    Multiplier,
                    Exponent);
            }
            return stringRepresentation;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DecimalFactor && Equals((DecimalFactor)obj);
        }

        public bool Equals(DecimalFactor other)
        {
            return Multiplier == other.Multiplier && Exponent == other.Exponent;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Multiplier * 397) ^ Exponent;
            }
        }

        public static bool operator ==(DecimalFactor left, DecimalFactor right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DecimalFactor left, DecimalFactor right)
        {
            return !left.Equals(right);
        }
    }
}

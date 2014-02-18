using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RomanNumeralTranslator
{
    public struct RomanNumber
    {
        public string StringRepresentation { get; private set; }

        public static RomanNumber Parse(string stringRepresentation)
        {
            var uppercased = stringRepresentation.ToUpper(CultureInfo.InvariantCulture);
            ValidateSameSymbolUpToThreeTimesInARow(stringRepresentation);
            return new RomanNumber(uppercased);
        }

        private static void ValidateSameSymbolUpToThreeTimesInARow(string stringRepresentation)
        {
            if (Regex.IsMatch(stringRepresentation, @"(.)\1{3,}"))
            {
                throw new ArgumentException(
                    string.Format(
                        "String representation of a roman number ({0}) was invalid. " +
                        "More than three same symbols in a row", stringRepresentation));
            }
        }

        public RomanNumber(string stringRepresentation)
            : this()
        {
            StringRepresentation = stringRepresentation;
        }
    }
}

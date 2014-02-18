using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace RomanNumeralTranslator
{
    public struct RomanNumber
    {
        public string StringRepresentation { get; private set; }

        public static RomanNumber Parse(string stringRepresentation)
        {
            var uppercased = stringRepresentation.ToUpper(CultureInfo.InvariantCulture);
            ValidateAllCharacters(uppercased);
            ValidateSameSymbolUpToThreeTimesInARow(uppercased);
            ValidateAtMostOneNumberInARowISubtractedFromAnother(uppercased);
            return new RomanNumber(uppercased);
        }

        public RomanNumber(string stringRepresentation)
            : this()
        {
            StringRepresentation = stringRepresentation;
        }

        private static void ValidateAllCharacters(string stringRepresentation)
        {
            var romanSymbols = RomanNumeralSymbol.All;
            foreach (var character in stringRepresentation)
            {
                if (!romanSymbols.Any(x => x.Symbol == character))
                {
                    throw new ArgumentException(
                        string.Format(
                        "String representation of a roman number ({0}) was invalid. " +
                        "Invalid symbol: {1}",
                        stringRepresentation,
                        character));
                }
            }
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

        private static void ValidateAtMostOneNumberInARowISubtractedFromAnother(string stringRepresentation)
        {
            int previousSymbolValue = int.MaxValue;
            int clusterLength = 0;

            foreach (RomanNumeralSymbol currentSymbol in stringRepresentation)
            {
                if (currentSymbol.Value < previousSymbolValue)
                {
                    //new cluster
                    previousSymbolValue = currentSymbol.Value;
                    clusterLength = 1;
                }
                else if (currentSymbol.Value == previousSymbolValue)
                {
                    //old cluster grows
                    clusterLength++;
                }
                else if (currentSymbol.Value > previousSymbolValue)
                {
                    //subtraction attempted

                    if (clusterLength > 1)
                    {
                        throw new ArgumentException(
                            string.Format("String representation of a roman number ({0}) was invalid. " +
                                          "More than one symbol to be subtracted.",
                                          stringRepresentation));
                    }

                    clusterLength = 1;
                    previousSymbolValue = currentSymbol.Value;
                }
            }
        }
    }
}

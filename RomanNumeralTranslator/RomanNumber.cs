using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace RomanNumeralTranslator
{
    public struct RomanNumber : IEnumerable<RomanNumeralSymbol>
    {
        public string StringRepresentation { get; private set; }

        public static RomanNumber Parse(string stringRepresentation)
        {
            var uppercased = stringRepresentation.ToUpper(CultureInfo.InvariantCulture);
            ValidateAllCharacters(uppercased);
            ValidateSameSymbolUpToThreeTimesInARow(uppercased);
            ValidateSubtractionRelatedRules(uppercased);
            return new RomanNumber(uppercased);
        }

        public RomanNumber(string stringRepresentation)
            : this()
        {
            StringRepresentation = stringRepresentation;
        }

        public IEnumerator<RomanNumeralSymbol> GetEnumerator()
        {
            foreach (var romanNumeral in StringRepresentation)
            {
                yield return (RomanNumeralSymbol)romanNumeral;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        private static void ValidateSubtractionRelatedRules(string stringRepresentation)
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

                    ValidateAtMostOneNumberInARowIsSubtractedFromAnother(stringRepresentation, clusterLength);

                    ValidatePowersOtherThanTenCannotBeSubtracted(stringRepresentation, previousSymbolValue);

                    ValidateNumbersSmallerThanTenTimesCannotBeSubtracted(
                        stringRepresentation,
                        previousSymbolValue,
                        currentSymbol.Value);

                    clusterLength = 1;
                    previousSymbolValue = currentSymbol.Value;
                }
            }
        }

        private static void ValidateAtMostOneNumberInARowIsSubtractedFromAnother(
            string stringRepresentation,
// ReSharper disable UnusedParameter.Local
            int clusterLength)
// ReSharper restore UnusedParameter.Local
        {
            if (clusterLength > 1)
            {
                throw new ArgumentException(
                    string.Format("String representation of a roman number ({0}) was invalid. " +
                                  "More than one symbol to be subtracted.",
                                  stringRepresentation));
            }
        }

        private static void ValidatePowersOtherThanTenCannotBeSubtracted(
            string stringRepresentation,
            int previousSymbolValue)
        {
            var isPowerOfTen = new DecimalFactor(previousSymbolValue).Multiplier == 1;
            if (!isPowerOfTen)
            {
                throw new ArgumentException(
                    string.Format("String representation of a roman number ({0}) was invalid. " +
                                  "Only powers of ten can be subtracted.",
                                  stringRepresentation));
            }
        }

        private static void ValidateNumbersSmallerThanTenTimesCannotBeSubtracted(
            string stringRepresentation,
            int previousSymbolValue,
            int currentSymbolValue)
        {
            var currentDecreasedTenTimes = currentSymbolValue/10;
            var currentIsBiggerThanTenTimes = currentDecreasedTenTimes > previousSymbolValue;

            if (currentIsBiggerThanTenTimes)
            {
                throw new ArgumentException(
                    string.Format("String representation of a roman number ({0}) was invalid. " +
                                  "Cannot subtract a number that is more than ten times smaller",
                                  stringRepresentation));
            }
        }
    }
}

using System;
using System.Text;

namespace RomanNumeralTranslator
{
    public static class Translator
    {
        public static string ToRoman(int integer)
        {
            if (integer < 1 || integer > 3000)
            {
                throw new ArgumentOutOfRangeException(
                    "integer",
                    "Only numbers from the range [1..3000] are supported");
            }

            var decimalFactors = DecimalFactorizer.Factorize(integer);
            var romanRepresentationParts = new StringBuilder();
            foreach (var decimalFactor in decimalFactors)
            {
                var part = DecimalFactorToRomanPartTranslator.Translate(decimalFactor);
                romanRepresentationParts.Append(part);
            }

            return romanRepresentationParts.ToString();
        }

        public static int ToInteger(string romanNumber)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Linq;
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

        public static int ToInteger(RomanNumber romanNumber)
        {
            var integer = 0;
            var symbols = romanNumber.ToList();

            for (int i = 0; i < symbols.Count-1; i++)
            {
                var current = symbols[i];
                var next = symbols[i + 1];

                if (next.Value <= current.Value)
                {
                    integer += current.Value;
                }
                else
                {
                    integer -= current.Value;
                }
            }

            integer += symbols.Last().Value;

            return integer;
        }
    }
}

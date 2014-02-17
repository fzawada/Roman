using System.Globalization;

namespace RomanNumeralTranslator
{
    public struct RomanNumber
    {
        public string StringRepresentation { get; private set; }

        public static RomanNumber Parse(string stringRepresentation)
        {
            var uppercased = stringRepresentation.ToUpper(CultureInfo.InvariantCulture);
            return new RomanNumber(uppercased);
        }

        public RomanNumber(string stringRepresentation)
            : this()
        {
            StringRepresentation = stringRepresentation;
        }
    }
}

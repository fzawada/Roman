namespace RomanNumeralTranslator
{
    public struct RomanNumber
    {
        public string StringRepresentation { get; private set; }

        public static RomanNumber Parse(string stringRepresentation)
        {
            return new RomanNumber(stringRepresentation.ToUpper());
        }

        public RomanNumber(string stringRepresentation)
            : this()
        {
            StringRepresentation = stringRepresentation;
        }
    }
}

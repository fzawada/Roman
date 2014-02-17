using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralTranslator
{
    public static class DecimalFactorizer
    {
        public static DecimalFactor[] Factorize(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Factorizing non-positive numbers is not supported");
            }

            var factors = new LinkedList<DecimalFactor>();
            var currentExponent = 0;
            while (number > 0)
            {
                var multiplier = number % 10;
                factors.AddFirst(new DecimalFactor(multiplier, currentExponent));

                currentExponent++;
                number /= 10;
            }

            return factors.ToArray();
        }
    }
}

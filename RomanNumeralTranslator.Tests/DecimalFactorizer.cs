using System;
using System.Linq;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests
{
    [TestFixture]
    class Decimal_factorizer_tests
    {
        [Test]
        [TestCase(1, new [] {1})]
        [TestCase(3, new [] {3})]
        [TestCase(13, 10, 3)]
        [TestCase(375, 300, 70, 5)]
        [TestCase(2375, 2000, 300, 70, 5)]
        public void Factorizes_to_correct_numbers(int numberToFactorize, params int [] expectedFactors)
        {
            //arrange
            var expectedDecimalFactors = from x in expectedFactors
                                         select new DecimalFactor(x);
            //act
            var actualDecimalFactors = DecimalFactorizer.Factorize(numberToFactorize);

            //assert
            Assert.That(
                actualDecimalFactors,
                Is.EquivalentTo(expectedDecimalFactors),
                "Input number to factorize: " + numberToFactorize);
        }

        [TestCase(375)]
        [TestCase(123)]
        [TestCase(321)]
        public void Factorized_parts_are_sorted_by_exponent_descending(int numberToFactorize)
        {
            //act
            var actualDecimalFactors = DecimalFactorizer.Factorize(numberToFactorize);

            //assert
            Assert.That(actualDecimalFactors, Is.Ordered.Descending.By("Exponent"));
        }

        [TestCase(0, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentException))]
        public void Throws_for_non_positive_numbers(int number)
        {
            //act
            DecimalFactorizer.Factorize(number);
        }
    }
}

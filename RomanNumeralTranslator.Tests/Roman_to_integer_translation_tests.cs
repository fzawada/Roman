using System;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests
{
    [TestFixture(Category = "acceptance")]
    class Roman_to_integer_translation_tests
    {
        [Test, Ignore("Acceptance test. The implementation is not ready yet.")]
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("VII", 7)]
        [TestCase("VIII", 8)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("XI", 11)]
        [TestCase("XII", 12)]
        [TestCase("XIII", 13)]
        [TestCase("XIV", 14)]
        [TestCase("LXIII", 63)]
        [TestCase("XCIX", 99)]
        [TestCase("CXLIX", 149)]
        [TestCase("DCLXVII", 667)]
        [TestCase("DCCCXCVIII", 898)]
        [TestCase("MCCCXXXVII", 1337)]
        [TestCase("MCMXCVI", 1996)]
        [TestCase("MMCMXCIX", 2999)]
        [TestCase("MMM", 3000)]
        [TestCase("IC", 0, ExpectedException = typeof (ArgumentException))]
        [TestCase("VX", 0, ExpectedException = typeof (ArgumentException))]
        public void Case(string romanNumber, int expectedInteger)
        {
            //act
            var actualInteger = Translator.ToInteger(romanNumber);

            //assert
            Assert.That(actualInteger, Is.EqualTo(expectedInteger),
                        "Input roman number: " + romanNumber);
        }
    }
}

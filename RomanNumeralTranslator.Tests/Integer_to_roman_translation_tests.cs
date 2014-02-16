using System;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests
{
    [Ignore("Not implemented yet. This is for final verification.")]
    [TestFixture(Category = "acceptance")]
    internal class Integer_to_roman_translation_tests
    {
        [Test]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(63, "LXIII")]
        [TestCase(99, "XCIX")]
        [TestCase(149, "CXLIX")]
        [TestCase(667, "DCLXVII")]
        [TestCase(898, "DCCCXCVIII")]
        [TestCase(1337, "MCCCXXXVII")]
        [TestCase(1996, "MCMXCVI")]
        [TestCase(2999, "MMCMXCIX")]
        [TestCase(3000, "MMM")]
        [TestCase(3001, "", ExpectedException = typeof (ArgumentOutOfRangeException))]
        [TestCase(0, "", ExpectedException = typeof (ArgumentOutOfRangeException))]
        [TestCase(-1, "", ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void Case(int integer, string expectedRoman)
        {
            //act
            var actualRoman = Translator.ToRoman(integer);

            //assert
            Assert.AreEqual(
                expectedRoman,
                actualRoman,
                string.Format(
                    "Input integer: {0}. {1}{2}  Roman ",
                    integer,
                    Environment.NewLine,
                    Environment.NewLine));
        }
    }
}

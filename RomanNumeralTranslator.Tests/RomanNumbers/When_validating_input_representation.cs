﻿using System;
using NUnit.Framework;

namespace RomanNumeralTranslator.Tests.RomanNumbers
{
    class When_validating_input_representation
    {
        [Test]
        [TestCase("A")]
        [TestCase(" A")]
        [TestCase("A.")]
        [TestCase("A.")]
        [TestCase("I I")]
        public void Should_reject_strings_with_invalid_characters(string inputRepresentation)
        {
            Assert.Throws(
                typeof (ArgumentException),
                () => RomanNumber.Parse(inputRepresentation),
                "Input representation: " + inputRepresentation);
        }

        [Test]
        [TestCase("IIII")]
        [TestCase("VVVV")]
        [TestCase("XXXX")]
        [TestCase("LLLL")]
        [TestCase("CCCC")]
        [TestCase("DDDD")]
        [TestCase("MMMM")]
        [TestCase("XXXX")]
        [TestCase("LLLL")]
        public void Same_symbol_cannot_be_used_more_than_three_times_in_a_row(string inputRepresentation)
        {
            //act and assert
            Assert.Throws(
                typeof(ArgumentException),
                () => RomanNumber.Parse(inputRepresentation),
                "Input representation: " + inputRepresentation);
        }

        [Test]
        [TestCase("XXXIX")]
        [TestCase("CCCXC")]
        public void Same_symbol_can_be_used_more_than_three_times_in_total(string inputRepresentation)
        {
            //act and assert
            Assert.DoesNotThrow(
                () => RomanNumber.Parse(inputRepresentation),
                "Input representation: " + inputRepresentation);
        }


    }
}

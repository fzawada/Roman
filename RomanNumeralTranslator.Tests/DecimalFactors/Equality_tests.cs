using NUnit.Framework;

namespace RomanNumeralTranslator.Tests.DecimalFactors
{
    [TestFixture]
    class Equality_tests
    {
        [Test]
        public void Equal_with_same_constructor_and_params()
        {
            //arrange
            var df1 = new DecimalFactor(1, 2);
            var df2 = new DecimalFactor(1, 2);

            //act & assert
            Assert.AreEqual(df1, df2);
        }

        [Test]
        public void Equal_with_different_constructors()
        {
            //arrange
            var df1 = new DecimalFactor(1, 2);
            var df2 = new DecimalFactor(100);

            //act & assert
            Assert.AreEqual(df1, df2);
        }

        [Test]
        public void Not_equal_when_different_inputs()
        {
            //arrange
            var df1 = new DecimalFactor(1, 2);
            var df2 = new DecimalFactor(1, 3);

            //act & assert
            Assert.AreNotEqual(df1, df2);
        }
    }
}

using NUnit.Framework;

namespace Kata.Diamond
{
    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void DiamondOfA()
        {
            var diamond = new Diamond("A");
            Assert.That(diamond.Generate(), Is.EqualTo("A"));
        }

        [Test]
        public void DiamondOfB_LetterAIsAtTheCenterWithSpacing()
        {
            var diamond = new Diamond("B");
            Assert.That(diamond.Generate(), Is.EqualTo("-A-"));
        }
    }

    public class Diamond
    {
        private string letter;

        public Diamond(string letter)
        {
            this.letter = letter;
        }

        public string Generate()
        {
            if (letter == "B")
            {
                return "-A-";
            }
            return "A";
        }
    }
}

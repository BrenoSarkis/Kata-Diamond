using System;
using System.Linq.Expressions;
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

        [Test]
        public void DiamondOfC_LetterAIsAtTheCenterWithSpacing()
        {
            var diamond = new Diamond("C");
            Assert.That(diamond.Generate(), Is.EqualTo("--A--"));
        }
    }

    public class Diamond
    {
        private readonly string letter;
        private readonly string[] alphabet = { "A", "B", "C" };
        private readonly int letterIndex = 0;
        private readonly int size = 0;

        public Diamond(string letter)
        {
            this.letter = letter;
            letterIndex = Array.FindIndex(alphabet, x => x == letter);
            size = letterIndex * 2 + 1;
        }

        public string Generate()
        {
            if (letterIndex > 0)
            {
                var diamond = "";
                var centerOfTheDiamond = size / 2;
                for (int i = 0; i < size; i++)
                {
                    if (i == centerOfTheDiamond)
                    {
                        diamond += "A";
                    }
                    else
                    {
                        diamond += "-";
                    }
                }

                return diamond;
            }
            return "A";
        }
    }
}

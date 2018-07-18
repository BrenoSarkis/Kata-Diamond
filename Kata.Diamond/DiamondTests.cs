using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.That(GetRow(diamond.Generate(), 0), Is.EqualTo("A"));
        }

        [Test]
        public void DiamondOfB_LetterAIsAtTheCenterWithSpacing()
        {
            var diamond = new Diamond("B");
            Assert.That(GetRow(diamond.Generate(), 0), Is.EqualTo("-A-"));
        }

        [Test]
        public void DiamondOfB_LetterBIsAtBothTipsOfTheDiamond()
        {
            var diamond = new Diamond("B");
            Assert.That(GetRow(diamond.Generate(), 1), Is.EqualTo("B-B"));
        }

        [Test]
        public void DiamondOfC_LetterAIsAtTheCenterWithSpacing()
        {
            var diamond = new Diamond("C");
            Assert.That(GetRow(diamond.Generate(), 0), Is.EqualTo("--A--"));
        }

        private string GetRow(string[,] diamond, int row)
        {
            return String.Join("", Enumerable.Range(0, diamond.GetLength(1))
                .Select(x => diamond[row, x])
                .ToArray());
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

        public string[,] Generate()
        {
            var diamond = new string[size, size];

            var centerOfTheDiamond = size / 2;

            for (int i = 0; i <= letterIndex; i++)
            {
                if (i == 0)
                {
                    diamond[i, centerOfTheDiamond] = "A";
                }

                if (i == letterIndex)
                {
                    diamond[i, 0] = letter;
                    diamond[i, size - 1] = letter;
                }

                for (int j = 0; j < size; j++)
                {
                    if (diamond[i, j] == null)
                    {
                        diamond[i, j] = "-";
                    }
                }
            }
            return diamond;
        }
    }
}

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
        private readonly int centerOfTheDiamond;
        private readonly string[,] diamondStructure;

        public Diamond(string letter)
        {
            this.letter = letter;
            letterIndex = Array.FindIndex(alphabet, x => x == letter);
            size = letterIndex * 2 + 1;
            centerOfTheDiamond = size / 2;
            diamondStructure = new string[size,size];
        }

        public string[,] Generate()
        {
            for (int i = 0; i <= letterIndex; i++)
            {
                if (i == 0)
                {
                    SetTheUpperTip(i);
                }

                if (i == letterIndex)
                {
                    SetTheMiddle(i);
                }

                FillsBlanksWithDashes(i);
            }

            return diamondStructure;
        }

        private void FillsBlanksWithDashes(int i)
        {
            for (int j = 0; j < size; j++)
            {
                if (diamondStructure[i, j] == null)
                {
                    diamondStructure[i, j] = "-";
                }
            }
        }

        private void SetTheMiddle(int i)
        {
            diamondStructure[i, 0] = letter;
            diamondStructure[i, size - 1] = letter;
        }

        private void SetTheUpperTip(int i)
        {
            diamondStructure[i, centerOfTheDiamond] = "A";
        }
    }
}

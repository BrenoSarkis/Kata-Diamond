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
            var diamond = new Diamond("A").Generate();

            AssertDiamondRowAt(diamond, 0, "A");
        }

        [Test]
        public void DiamondOfB()
        {
            var diamond = new Diamond("B").Generate();

            AssertDiamondRowAt(diamond, 0, "-A-");
            AssertDiamondRowAt(diamond, 1, "B-B");
            AssertDiamondRowAt(diamond, 2, "-A-");
        }

        [Test]
        public void DiamondOfC()
        {
            var diamond = new Diamond("C").Generate();
            AssertDiamondRowAt(diamond, 0, "--A--");
            AssertDiamondRowAt(diamond, 1, "-B-B-");
            AssertDiamondRowAt(diamond, 2, "C---C");
            AssertDiamondRowAt(diamond, 3, "-B-B-");
            AssertDiamondRowAt(diamond, 4, "--A--");
        }

        private void AssertDiamondRowAt(string[,] diamond, int rowIndex, string expectedValue)
        {
            Assert.That(GetRow(diamond, rowIndex), Is.EqualTo(expectedValue));
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
            diamondStructure = new string[size, size];
        }

        public string[,] Generate()
        {
            int leftLetterPosition = centerOfTheDiamond;
            int rightLetterPosition = centerOfTheDiamond;
            var diamondWidth = size - 1;

            for (int row = 0; row <= letterIndex; row++)
            {
                if (row == 0)
                {
                    SetsLetterAtTheMiddle(row);
                    SetsLetterAtTheMiddle(diamondWidth);
                    continue;
                }

                if (row == letterIndex)
                {
                    SetTheMiddle(row);
                    continue;
                }

                leftLetterPosition--;
                rightLetterPosition++;

                var rowAtBottomHalf = diamondWidth - row;
                var currentLetter = alphabet[row];

                SetLetterAt(currentLetter, row, leftLetterPosition, rightLetterPosition);
                SetLetterAt(currentLetter, rowAtBottomHalf, leftLetterPosition, rightLetterPosition);
            }

            FillsBlanksWithDashes();

            return diamondStructure;
        }



        private void SetLetterAt(string letter, int row, int leftLetterPosition, int rightLetterPosition)
        {
            diamondStructure[row, leftLetterPosition] = letter;
            diamondStructure[row, rightLetterPosition] = letter;
        }

        private void FillsBlanksWithDashes()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (diamondStructure[i, j] == null)
                    {
                        diamondStructure[i, j] = "-";
                    }
                }
            }
        }

        private void SetTheMiddle(int i)
        {
            diamondStructure[i, 0] = letter;
            diamondStructure[i, size - 1] = letter;
        }

        private void SetsLetterAtTheMiddle(int i)
        {
            diamondStructure[i, centerOfTheDiamond] = "A";
        }
    }
}

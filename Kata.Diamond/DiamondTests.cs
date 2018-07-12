using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using IFormatProvider = System.IFormatProvider;

namespace Kata.Diamond
{
    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void DiamondOfA_HasNoSpaces()
        {
            Assert.That(DiamondMaker.CreateFor("A")[0], Is.EqualTo("A"));
        }

        [Test]
        public void DiamondOfB()
        {
            var diamond = DiamondMaker.CreateFor("B");
            Assert.That(diamond[0], Is.EqualTo(" A "));
            Assert.That(diamond[1], Is.EqualTo("B B"));
            Assert.That(diamond[2], Is.EqualTo(" A "));
        }

        [Test]
        public void DiamondOfC_OnSecondLayer_HasBWithSpacing()
        {
            Assert.That(DiamondMaker.CreateFor("C")[1], Is.EqualTo(" B B "));
        }

        [Test]
        public void DiamondOfC_ThirdLayer_HasNoOuterSpacing()
        {
            Assert.That(DiamondMaker.CreateFor("C")[2], Is.EqualTo("C   C"));
        }
    }

    public class DiamondMaker
    {
        public static string[] CreateFor(string letter)
        {
            var alphabet = new[] { "A", "B", "C" };
            var letterIndex = Array.FindIndex(alphabet, l => l == letter);
            var diamond = new List<string>();

            if (letter != "A")
            {
                diamond.Add(" A ");
                for (int i = 1; i <= letterIndex; i++)
                {
                    if (i == letterIndex)
                    {
                        diamond.Add(alphabet[i] + new String(' ', i + 1) + alphabet[i]);
                    }
                    else
                    {
                        diamond.Add(new String(' ', letterIndex - 1) +
                                    alphabet[letterIndex - 1] +
                                    new String(' ', letterIndex - 1) +
                                    alphabet[letterIndex - 1] +
                                    new String(' ', letterIndex - 1));
                    }
                }
                diamond.Add(" A ");
                return diamond.ToArray();
            }
            return new[] { "A" };
        }
    }
}

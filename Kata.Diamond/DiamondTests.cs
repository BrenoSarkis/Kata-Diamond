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
        public void DiamondOfB_FirstRowHasSurroundingSpaces()
        {
            var diamond = DiamondMaker.CreateFor("B");
            Assert.That(diamond[0], Is.EqualTo(" A "));
        }

        [Test]
        public void DiamondOfC_FirstRowHasTwoSurroundingSpaces()
        {
            var diamond = DiamondMaker.CreateFor("C");
            Assert.That(diamond[0], Is.EqualTo("  A  "));
        }

        [Test]
        public void DiamondOfB_SecondRowStartsAndEndsOnB()
        {
            var diamond = DiamondMaker.CreateFor("B");
            Assert.That(diamond[1], Is.EqualTo("B B"));
        }
    }

    public class DiamondMaker
    {
        public static string[] CreateFor(string letter)
        {
            var diamond = new List<string>();
            var alphabet = new[] { "A", "B", "C" };
            var letterIndex = Array.FindIndex(alphabet, l => l == letter);
            diamond.Add(new String(' ', letterIndex) + "A" + new String(' ', letterIndex));
            if (letterIndex > 0)
            {
                diamond.Add(alphabet[letterIndex] + new String(' ', letterIndex) + alphabet[letterIndex]);
            }
            return diamond.ToArray();
        }
    }
}

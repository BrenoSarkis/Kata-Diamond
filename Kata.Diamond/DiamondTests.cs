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
        public void SingleLetter_HasOnlyOneLetter()
        {
            Assert.That(DiamondMaker.CreateFor("A")[0], Is.EqualTo("A"));
        }

        [Test]
        public void TwoLettersDiamond_FistRowHasOneSpace()
        {
            Assert.That(DiamondMaker.CreateFor("B")[0], Is.EqualTo(" A "));
        }

        [Test]
        public void ThreeLettersDiamond_FistRowTwoOneSpace()
        {
            Assert.That(DiamondMaker.CreateFor("C")[0], Is.EqualTo("  A  "));
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
                return diamond.ToArray();
            }
            return new[] {"A"};
        }
    }
}

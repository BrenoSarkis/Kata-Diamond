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
                if (letterIndex > 1)
                {
                    diamond.Add(new String(' ', letterIndex - 1) + 
                                alphabet[letterIndex - 1] + 
                                new String(' ', letterIndex - 1) + 
                                alphabet[letterIndex - 1] + 
                                new String(' ', letterIndex - 1));
                }
                else
                {
                    diamond.Add("B B");
                }
                diamond.Add(" A ");
                return diamond.ToArray();
            }
            return new[] { "A" };
        }
    }
}

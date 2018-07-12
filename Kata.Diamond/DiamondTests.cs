using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Kata.Diamond
{
    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void DiamondOfA()
        {
            Assert.That(DiamondMaker.CreateFor("A")[0], Is.EqualTo("A"));
        }

        [Test]
        public void DiamondOfB()
        {
            var diamondOfB = DiamondMaker.CreateFor("B");
            Assert.That(diamondOfB[0], Is.EqualTo(" A "));
            Assert.That(diamondOfB[1], Is.EqualTo("B B"));
            Assert.That(diamondOfB[2], Is.EqualTo(" A "));
        }

        [Test]
        public void DiamondOfC_FirstLayer_StartsWithA()
        {
            Assert.That(DiamondMaker.CreateFor("C")[0], Is.EqualTo(" A "));
        }

        [Test]
        public void DiamondOfC_SecondLayer_HasBWithSpaces()
        {
            Assert.That(DiamondMaker.CreateFor("C")[1], Is.EqualTo("B B"));
        }

        [Test]
        public void DiamondOfC_ThirdLayer_HasCWithSpaces()
        {
            Assert.That(DiamondMaker.CreateFor("C")[2], Is.EqualTo("C  C"));
        }
    }

    public class DiamondMaker
    {
        public static string[] CreateFor(string letter)
        {
            var alphabet = new[] { "A", "B", "C"};
            var letterIndex = Array.FindIndex(alphabet, l => l == letter);
            var diamondLayers = new List<string>();

            if (letter != "A")
            {
                diamondLayers.Add(" A ");
                for (int i = 1; i <= letterIndex; i++)
                {
                    diamondLayers.Add(alphabet[i] + new String(' ', i) + alphabet[i]);
                }
                diamondLayers.Add(" A ");
                return diamondLayers.ToArray();
            }
            return new []{ "A" };
        }
    }
}

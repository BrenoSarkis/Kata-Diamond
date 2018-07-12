using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    public class DiamondMaker
    {
        public static string[] CreateFor(string letter)
        {
            var diamondLayers = new List<string>();

            if (letter != "A")
            {
                diamondLayers.Add(" A ");
                diamondLayers.Add("B B");
                diamondLayers.Add(" A ");
                return diamondLayers.ToArray();
            }
            return new []{ "A" };
        }
    }
}

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
        public void DiamondOfB_SurroundsAWithEmptySpaces()
        {
            Assert.That(DiamondMaker.CreateFor("B")[0], Is.EqualTo(" A "));
        }

        [Test]
        public void DiamondOfB_SecondLayer_CreatesBWithAnSpaceInBetween()
        {
            Assert.That(DiamondMaker.CreateFor("B")[1], Is.EqualTo("B B"));
        }
    }

    public class DiamondMaker
    {
        public static string[] CreateFor(string letter)
        {
            var diamondLayers = new List<string>();
            if (letter == "B")
            {
                diamondLayers.Add(" A ");
                diamondLayers.Add("B B");
                return diamondLayers.ToArray();
            }
            return new []{ "A" };
        }
    }
}

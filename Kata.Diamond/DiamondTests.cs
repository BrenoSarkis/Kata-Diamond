using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        public void DiamondOfA_HasNoSpaces()
        {
            Assert.That(DiamondMaker.CreateFor("A")[0], Is.EqualTo("A"));
        }

        [Test]
        public void DiamondOfB_HasASpaceInBetween()
        {
            Assert.That(DiamondMaker.CreateFor("B")[1], Is.EqualTo("B B"));
        }

        [Test]
        public void DiamondOfB_BeginsWithAWithSpaces()
        {
            Assert.That(DiamondMaker.CreateFor("B")[0], Is.EqualTo(" A "));
        }
    }

    public class DiamondMaker
    {
        public static string[]  CreateFor(string letter)
        {
            var diamond = new List<string>();
            if (letter == "B")
            {
                diamond.Add(" A ");
                diamond.Add("B B");
                return diamond.ToArray();
            }
            return  new []{"A"} ;
        }
    }
}

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
        public void OneRowDiamond_HasOnlyOneLetter()
        {
            Assert.That(DiamondMaker.CreateFor("A"), Is.EqualTo("A"));
        }

    }

    public class DiamondMaker
    {
        public static string CreateFor(string letter)
        {
            return "A";
        }
    }
}

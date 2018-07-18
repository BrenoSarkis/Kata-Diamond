﻿using NUnit.Framework;

namespace Kata.Diamond
{
    [TestFixture]
    public class DiamondTests
    {
        [Test]
        public void DiamondOfA()
        {
            var diamond = new Diamond("A");
            Assert.That(diamond.Generate(), Is.EqualTo("A"));
        }
    }

    public class Diamond
    {
        private string letter;

        public Diamond(string letter)
        {
            this.letter = letter;
        }

        public string Generate()
        {
            return "A";
        }
    }
}

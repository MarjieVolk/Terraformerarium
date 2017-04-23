using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Tests
{
    using NUnit.Framework;

    [TestFixture]
    internal sealed class MultisetTests
    {
        [Test]
        public void TestMultiset()
        {
            var m = new Multiset<string>(new []
            {
                "a",
                "a"
            });
            Assert.AreEqual(true, m.Contains("a"));
        }
    }
}

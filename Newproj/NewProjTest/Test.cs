using NUnit.Framework;
using System;
namespace NewProjTest
{
    public class Test
    {
        [TestFixture]
        public class CalculatorTests
        {

            [Test]
            public void Addition_TestCase()
            {
                var s = new Math();
                var result = s.Addition(10, 20);
                Assert.AreEqual(result, 30);
            }

            
        }
    }
}
using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Multiplier.Tests
{
    [TestFixture]
    public class MainViewModelTest
    {
        MainViewModel main;
        [SetUp]
        public void Setup()
        {
            main = new MainViewModel();
        }

        [Test]
        public void MultiplyTest()
        {

            var x = main.Multiply(2, 4);
            var y = main.Multiply(0, 0);
            Assert.AreEqual(8, x);
            Assert.AreEqual(y, 0);
            Assert.DoesNotThrow(() => main.Multiply(1, 0));
        }
    }
}

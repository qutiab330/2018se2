using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Multiplier.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void MultiplicationTest()
        {
            app.Tap("FirstNumberEntry");
            app.EnterText("2");
            app.Back();
            app.Tap("SecondNumberEntry");
            app.EnterText("4");
            app.Back();
            app.WaitForElement(x => x.Marked("ResultLabel").Text("8"));
        }
    }
}

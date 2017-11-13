using NUnit.Framework;

namespace MFU.Utils.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Utils.Tests")]
    public class MockGeneratorTest
    {
        [Test]
        public void Should_GetString_Default_MaxSize()
        {
            var actual = MockGenerator.GetString();
            Assert.AreEqual(1, actual.Length);
        }

        [Test]
        public void Should_GetString_Set_MaxSize()
        {
            var actual = MockGenerator.GetString(50);
            Assert.AreEqual(50, actual.Length);
        }

        [Test]
        public void Should_GetString_Set_Zero_MaxSize()
        {
            var actual = MockGenerator.GetString(0);
            Assert.AreEqual(0, actual.Length);
        }
    }
}

using WpfJikken6.ValueObject;

namespace WpfJikken6.Tests.ValueObject
{
    [TestFixture]
    public class SequentialBytesValueTest
    {
        [Test]
        public void Constructor_CreatesCorrectObject()
        {
            var binary = new byte[] { 0x9D, 0x08 };
            var value = new SequentialBytesValue(binary);

            Assert.Multiple(() =>
            {
                Assert.That(value.Original, Is.EqualTo(new byte[] { 0x9D, 0x08 }));
                Assert.That(value.Modified, Is.EqualTo(new byte[] { 0x9D, 0x08 }));
                Assert.That(value.Original, Is.Not.SameAs(binary));
                Assert.That(value.Modified, Is.Not.SameAs(binary));
            });
        }

        [TestCase(new byte[] { 0x72, 0x06 }, 1650)]
        [TestCase(new byte[] { 0x08, 0x9D }, 40200)]
        [TestCase(new byte[] { 0x78, 0x56, 0x34 }, 0x345678)]
        public void Int_ReturnsCorrectValue(byte[] binary, int expected)
        {
            var value = new SequentialBytesValue(binary);
            Assert.That(value.Int, Is.EqualTo(expected));
        }

        [TestCase(1650, new byte[] { 0x72, 0x06 })]
        [TestCase(40200, new byte[] { 0x08, 0x9D })]
        public void SetValue_ModifiesBytesCorrectly(int newValue, byte[] expected)
        {
            var initial = new byte[] { 0xFF, 0xFF };
            var value = new SequentialBytesValue(initial);

            value.SetValue(newValue);

            Assert.Multiple(() =>
            {
                Assert.That(value.Modified, Is.EqualTo(expected));
                Assert.That(value.Original, Is.EqualTo(initial));
            });
        }
    }
}

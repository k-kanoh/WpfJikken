using WpfJikken6.ValueObject;

namespace WpfJikken6.Tests.ValueObject
{
    [TestFixture]
    public class SingleByteValueTest
    {
        [Test]
        public void Constructor_WithoutPattern()
        {
            var value = new SingleByteValue(0xA5);

            Assert.Multiple(() =>
            {
                Assert.That(value.Original, Is.EqualTo(0xA5));
                Assert.That(value.Modified, Is.EqualTo(0xA5));
                Assert.That(value.BitPos.Bytes, Is.EqualTo(new byte[] { 0xFF }));
            });
        }

        [Test]
        public void Constructor_WithPattern()
        {
            var value = new SingleByteValue(0xA5, "11110000");

            Assert.Multiple(() =>
            {
                Assert.That(value.Original, Is.EqualTo(0xA5));
                Assert.That(value.Modified, Is.EqualTo(0xA5));
                Assert.That(value.BitPos.Bytes, Is.EqualTo(new byte[] { 0xF0 }));
            });
        }

        [TestCase("11110000", 0xA5, 10)]
        [TestCase("00001111", 0xFF, 15)]
        [TestCase("01111111", 0xC1, 65)]
        public void Int_ReturnsCorrectValue(string pattern, byte binary, int expected)
        {
            var value = new SingleByteValue(binary, pattern);
            Assert.That(value.Int, Is.EqualTo(expected));
        }

        [TestCase("11110000", 3, 0x3F)]
        [TestCase("01111111", 5, 0x85)]
        public void SetValue_ModifiesByteCorrectly(string pattern, int newValue, byte expected)
        {
            var value = new SingleByteValue(0xFF, pattern);
            value.SetValue(newValue);

            Assert.Multiple(() =>
            {
                Assert.That(value.Modified, Is.EqualTo(expected));
                Assert.That(value.Original, Is.EqualTo(0xFF));
            });
        }
    }
}

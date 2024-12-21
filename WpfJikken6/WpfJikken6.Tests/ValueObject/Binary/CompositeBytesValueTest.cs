using WpfJikken6.ValueObject;

namespace WpfJikken6.Tests.ValueObject
{
    [TestFixture]
    public class CompositeBytesValueTest
    {
        [Test]
        public void Constructor_CreatesCorrectObjectWithoutPattern()
        {
            var binary = new byte[] { 0x02, 0x82 };
            var value = new CompositeBytesValue(binary);

            Assert.Multiple(() =>
            {
                Assert.That(value.Original, Is.EqualTo(new byte[] { 0x02, 0x82 }));
                Assert.That(value.Modified, Is.EqualTo(new byte[] { 0x02, 0x82 }));
                Assert.That(value.Original, Is.Not.SameAs(binary));
                Assert.That(value.Modified, Is.Not.SameAs(binary));
                Assert.That(value.BitPos.Bytes, Is.EqualTo(new byte[] { 0xFF, 0xFF }));
            });
        }

        [Test]
        public void Constructor_CreatesCorrectObjectWithPattern()
        {
            var binary = new byte[] { 0xCB, 0xE1 };
            var value = new CompositeBytesValue(binary, "1100000010000000");

            Assert.Multiple(() =>
            {
                Assert.That(value.Original, Is.EqualTo(new byte[] { 0xCB, 0xE1 }));
                Assert.That(value.Modified, Is.EqualTo(new byte[] { 0xCB, 0xE1 }));
                Assert.That(value.BitPos.Bytes, Is.EqualTo(new byte[] { 0xC0, 0x80 }));
            });
        }

        [TestCase(new byte[] { 0x02, 0x82 }, "1000000010000000", 1)]
        [TestCase(new byte[] { 0xCB, 0xE1 }, "1100000010000000", 7)]
        [TestCase(new byte[] { 0xFD, 0x5E }, "0000001111111111", 350)]
        [TestCase(new byte[] { 0x3F, 0xFF }, "0000001111111111", 1023)]
        public void Int_ReturnsCorrectValue(byte[] binary, string pattern, int expected)
        {
            var value = new CompositeBytesValue(binary, pattern);
            Assert.That(value.Int, Is.EqualTo(expected));
        }

        [TestCase("1000000010000000", 1, new byte[] { 0x7F, 0xFF })]
        [TestCase("1100000010000000", 4, new byte[] { 0xBF, 0x7F })]
        [TestCase("0000001111111111", 350, new byte[] { 0xFD, 0x5E })]
        [TestCase("0000001111111111", 1023, new byte[] { 0xFF, 0xFF })]
        public void SetValue_ModifiesBytesCorrectly(string pattern, int newValue, byte[] expected)
        {
            var initial = new byte[] { 0xFF, 0xFF };
            var value = new CompositeBytesValue(initial, pattern);

            value.SetValue(newValue);

            Assert.Multiple(() =>
            {
                Assert.That(value.Modified, Is.EqualTo(expected));
                Assert.That(value.Original, Is.EqualTo(initial));
            });
        }
    }
}

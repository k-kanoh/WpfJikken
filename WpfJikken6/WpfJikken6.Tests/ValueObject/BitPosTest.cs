using WpfJikken6.ValueObject;

namespace WpfJikken6.Tests.ValueObject
{
    [TestFixture]
    public class BitPosTest
    {
        [Test]
        public void Constructor_CreatesCorrectObject()
        {
            var bitPos = new BitPos("1100000010000000");

            Assert.Multiple(() =>
            {
                Assert.That(bitPos.Bytes, Is.EqualTo(new byte[] { 0xC0, 0x80 }));
                Assert.That(bitPos.Patterns, Is.EqualTo(new[] { "11000000", "10000000" }));
            });
        }

        [TestCase("11000000", 3, 0xC0)]
        [TestCase("00000011", 3, 0x03)]
        [TestCase("10101010", 5, 0x22)]
        [TestCase("11110000", 15, 0xF0)]
        [TestCase("00001111", 15, 0x0F)]
        public void GetLayoutedByte_ReturnsCorrectValue(string pattern, int value, int expected)
        {
            var bitPos = new BitPos(pattern);
            Assert.That(bitPos.GetLayoutedByte(value), Is.EqualTo(expected));
        }

        [TestCase("1000000010000000", 1, new[] { 0x00, 0x80 })]
        [TestCase("1100000010000000", 7, new[] { 0xC0, 0x80 })]
        [TestCase("0000001111111111", 350, new[] { 0x01, 0x5E })]
        [TestCase("0000001111111111", 1023, new[] { 0x03, 0xFF })]
        public void GetLayoutedByteArray_HandlesMultipleBytes(string pattern, int value, int[] expected)
        {
            var bitPos = new BitPos(pattern);
            Assert.That(bitPos.GetLayoutedByteArray(value), Is.EqualTo(expected));
        }

        [TestCase("11000000", 0xC0, 3)]
        [TestCase("00000011", 0x03, 3)]
        [TestCase("10101010", 0x22, 5)]
        [TestCase("11110000", 0xF0, 15)]
        [TestCase("00001111", 0x0F, 15)]
        public void GetValueFromByte_ExtractsCorrectBits(string pattern, int value, int expected)
        {
            var bitPos = new BitPos(pattern);
            Assert.That(bitPos.GetValueFromByte(value), Is.EqualTo(expected));
        }

        [TestCase("1000000010000000", new byte[] { 0x02, 0x82 }, 1)]
        [TestCase("1100000010000000", new byte[] { 0xCB, 0xE1 }, 7)]
        [TestCase("0000001111111111", new byte[] { 0xFD, 0x5E }, 350)]
        [TestCase("0000001111111111", new byte[] { 0x3F, 0xFF }, 1023)]
        public void GetValueFromByteArray_ExtractsCorrectBits(string pattern, byte[] value, int expected)
        {
            var bitPos = new BitPos(pattern);
            Assert.That(bitPos.GetValueFromByteArray(value), Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x00, 0x00 }, 0)]
        [TestCase(new byte[] { 0x00, 0x80 }, 1)]
        [TestCase(new byte[] { 0x40, 0x00 }, 2)]
        [TestCase(new byte[] { 0x40, 0x80 }, 3)]
        [TestCase(new byte[] { 0x80, 0x00 }, 4)]
        [TestCase(new byte[] { 0x80, 0x80 }, 5)]
        [TestCase(new byte[] { 0xC0, 0x00 }, 6)]
        [TestCase(new byte[] { 0xC0, 0x80 }, 7)]
        public void GetValueFromByteArray_HandlesSpecificPattern(byte[] value, int expected)
        {
            var bitPos = new BitPos("1100000010000000");
            Assert.That(bitPos.GetValueFromByteArray(value), Is.EqualTo(expected));
        }

        [TestCase(1, new[] { 0xFF })]
        [TestCase(2, new[] { 0xFF, 0xFF })]
        [TestCase(3, new[] { 0xFF, 0xFF, 0xFF })]
        public void GetDefault_CreatesCorrectSizedArray(int size, int[] expected)
        {
            var bitPos = BitPos.GetDefault(size);
            Assert.That(bitPos.Bytes, Is.EqualTo(expected));
        }
    }
}

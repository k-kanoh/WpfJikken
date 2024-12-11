using WpfJikken6.Utility;

namespace WpfJikken6.Tests
{
    [TestFixture]
    public class NumberConverterTests
    {
        [TestCase("1A", 26)]
        [TestCase("FF", 255)]
        [TestCase("0", 0)]
        public void HexToIntBigEndian_ShouldConvertCorrectly(string hex, int expected)
        {
            var result = NumberConverter.HexToIntBigEndian(hex);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void HexToIntLittleEndian_ShouldConvertCorrectly()
        {
            string hex = "12345678";
            int expected = 0x78563412;

            var result = NumberConverter.HexToIntLittleEndian(hex);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("1A", 0x1A)]
        [TestCase("FF", 0xFF)]
        [TestCase("0", 0)]
        public void HexToByte_ShouldConvertCorrectly(string hex, byte expected)
        {
            var result = NumberConverter.HexToByte(hex);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void HexToByteArray_ShouldConvertCorrectly()
        {
            string hex = "12345678";
            byte[] expected = [0x12, 0x34, 0x56, 0x78];

            var result = NumberConverter.HexToByteArray(hex);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void HexToByteArray_ShouldHandleOddLengthString()
        {
            string hex = "123";
            byte[] expected = [0x01, 0x23];

            var result = NumberConverter.HexToByteArray(hex);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(26, "1A")]
        [TestCase(255, "FF")]
        [TestCase(0, "00")]
        public void ToHexBigEndian_ShouldConvertCorrectly(int value, string expected)
        {
            var result = NumberConverter.ToHexBigEndian(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToHexLittleEndian_ShouldConvertCorrectly()
        {
            int value = 0x12345678;
            string expected = "78563412";

            var result = NumberConverter.ToHexLittleEndian(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("10000000", 128)]
        [TestCase("00000001", 1)]
        [TestCase("11111111", 255)]
        public void BinToInt_ShouldConvertCorrectly(string binary, int expected)
        {
            var result = NumberConverter.BinToInt(binary);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("10000000", 128)]
        [TestCase("00000001", 1)]
        [TestCase("11111111", 255)]
        public void BinToByte_ShouldConvertCorrectly(string binary, byte expected)
        {
            var result = NumberConverter.BinToByte(binary);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0x1A, 26)]
        [TestCase(0xFF, 255)]
        public void ToInt_ShouldConvertCorrectly(byte value, int expected)
        {
            var result = NumberConverter.ToInt(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0x1A, "1A")]
        [TestCase(0xFF, "FF")]
        [TestCase(0x00, "00")]
        public void ToHex_ShouldConvertCorrectly(byte value, string expected)
        {
            var result = NumberConverter.ToHex(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

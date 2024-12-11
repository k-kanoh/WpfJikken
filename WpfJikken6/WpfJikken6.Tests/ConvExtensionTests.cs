namespace WpfJikken6.Tests
{
    [TestFixture]
    public class ConvExtensionTests
    {
        [TestCase("1A", 26)]
        [TestCase("FF", 255)]
        [TestCase("0", 0)]
        public void HexToInt_ShouldConvertCorrectly(string hex, int expected)
        {
            var result = hex.HexToInt();
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("1A", 0x1A)]
        [TestCase("FF", 0xFF)]
        [TestCase("0", 0)]
        public void HexToByte_ShouldConvertCorrectly(string hex, byte expected)
        {
            var result = hex.HexToByte();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void HexToByteArrayBigEndian_ShouldConvertCorrectly()
        {
            string hex = "12345678";
            byte[] expected = [0x12, 0x34, 0x56, 0x78];

            var result = hex.HexToByteArrayBigEndian();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void HexToByteArrayLittleEndian_ShouldConvertCorrectly()
        {
            string hex = "12345678";
            byte[] expected = [0x78, 0x56, 0x34, 0x12];

            var result = hex.HexToByteArrayLittleEndian();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void HexToByteArray_ShouldHandleOddLengthString()
        {
            string hex = "123";
            byte[] expectedBig = [0x01, 0x23];
            byte[] expectedLittle = [0x23, 0x01];

            var resultBig = hex.HexToByteArrayBigEndian();
            var resultLittle = hex.HexToByteArrayLittleEndian();

            Assert.That(resultBig, Is.EqualTo(expectedBig));
            Assert.That(resultLittle, Is.EqualTo(expectedLittle));
        }

        [Test]
        public void ToHex_Int_ShouldConvertCorrectly()
        {
            int value = 26;
            string expected = "1A";

            var result = value.ToHex();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToHex_Byte_ShouldConvertCorrectly()
        {
            byte value = 0x1A;
            string expected = "1A";

            var result = value.ToHex();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToInt_Byte_ShouldConvertCorrectly()
        {
            byte value = 0x1A;
            int expected = 26;

            var result = value.ToInt();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

using WpfJikken6.Utility;

namespace WpfJikken6.Tests.Utility
{
    [TestFixture]
    public class NumberConverterTests
    {
        [TestCase("A", 10)]
        [TestCase("00", 0)]
        [TestCase("FF", 255)]
        [TestCase("FFF", 4095)]
        [TestCase("FFFF", 65535)]
        [TestCase("FFFFF", 1048575)]
        [TestCase("FFFFFF", 16777215)]
        public void HexToInt_ValidInput(string hex, int expected)
        {
            Assert.That(NumberConverter.HexToInt(hex), Is.EqualTo(expected));
        }

        [TestCase(0x00, 0)]
        [TestCase(0xFF, 255)]
        public void ByteToInt_NoMask(byte value, int expected)
        {
            Assert.That(NumberConverter.ByteToInt(value), Is.EqualTo(expected));
        }

        [TestCase(0xA5, "11110000", 160)]
        [TestCase(0xFF, "00001111", 15)]
        [TestCase(0xC1, "01111111", 65)]
        public void ByteToInt_WithMask(byte value, string mask, int expected)
        {
            Assert.That(NumberConverter.ByteToInt(value, mask), Is.EqualTo(expected));
        }

        [TestCase(0x00, "00")]
        [TestCase(0xFF, "FF")]
        public void ByteToHex_NoMask(byte value, string expected)
        {
            Assert.That(NumberConverter.ByteToHex(value), Is.EqualTo(expected));
        }

        [TestCase(0xA5, "11110000", "A0")]
        [TestCase(0xFF, "00001111", "0F")]
        [TestCase(0xC1, "01111111", "41")]
        public void ByteToHex_WithMask(byte value, string mask, string expected)
        {
            Assert.That(NumberConverter.ByteToHex(value, mask), Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x06, 0x72 }, 1650)]
        [TestCase(new byte[] { 0x9D, 0x08 }, 40200)]
        public void ByteArrayToInt_NoMask(byte[] values, int expected)
        {
            Assert.That(NumberConverter.ByteArrayToInt(values), Is.EqualTo(expected));
        }

        [Test]
        public void ByteArrayToInt_WithMask()
        {
            Assert.Multiple(() =>
            {
                {
                    byte[] value = [0x02, 0x82];
                    string[] masks = ["10000000", "10000000"];
                    Assert.That(NumberConverter.ByteArrayToInt(value, masks), Is.EqualTo(1));
                }
                {
                    byte[] value = [0xCB, 0xE1];
                    string[] masks = ["11000000", "10000000"];
                    Assert.That(NumberConverter.ByteArrayToInt(value, masks), Is.EqualTo(7));
                }
                {
                    byte[] value = [0xFD, 0x5E];
                    string[] masks = ["00000011", "11111111"];
                    Assert.That(NumberConverter.ByteArrayToInt(value, masks), Is.EqualTo(350));
                }
                {
                    byte[] value = [0x3F, 0xFF];
                    string[] masks = ["00000011", "11111111"];
                    Assert.That(NumberConverter.ByteArrayToInt(value, masks), Is.EqualTo(1023));
                }
            });
        }

        [TestCase(new byte[] { 0x00, 0x00 }, 0)]
        [TestCase(new byte[] { 0x00, 0x80 }, 1)]
        [TestCase(new byte[] { 0x40, 0x00 }, 2)]
        [TestCase(new byte[] { 0x40, 0x80 }, 3)]
        [TestCase(new byte[] { 0x80, 0x00 }, 4)]
        [TestCase(new byte[] { 0x80, 0x80 }, 5)]
        [TestCase(new byte[] { 0xC0, 0x00 }, 6)]
        [TestCase(new byte[] { 0xC0, 0x80 }, 7)]
        public void ByteArrayToInt_WithMask_Focused(byte[] values, int expected)
        {
            Assert.That(NumberConverter.ByteArrayToInt(values, ["11000000", "10000000"]), Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x72, 0x06 }, 1650)]
        [TestCase(new byte[] { 0x08, 0x9D }, 40200)]
        public void ByteArrayToIntLittleEndian_ValidInput(byte[] values, int expected)
        {
            Assert.That(NumberConverter.ByteArrayToIntReverse(values), Is.EqualTo(expected));
        }

        [TestCase(new byte[] { 0x26, 0x66, 0x27, 0x46 }, "26662746")]
        [TestCase(new byte[] { 0xEA, 0xEA, 0xEA, 0xEA }, "EAEAEAEA")]
        public void ByteArrayToHex_ValidInput(byte[] values, string expected)
        {
            Assert.That(NumberConverter.ByteArrayToHex(values), Is.EqualTo(expected));
        }
    }
}

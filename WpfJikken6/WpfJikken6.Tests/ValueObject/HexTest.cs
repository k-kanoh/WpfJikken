using WpfJikken6.ValueObject;

namespace WpfJikken6.Tests.ValueObject
{
    [TestFixture]
    public class HexTest
    {
        [TestCase("A", 10)]
        [TestCase("00", 0)]
        [TestCase("FF", 255)]
        [TestCase("FFF", 4095)]
        [TestCase("FFFF", 65535)]
        [TestCase("FFFFF", 1048575)]
        [TestCase("FFFFFF", 16777215)]
        public void Constructor_CreatesCorrectObject(string hex, int expected)
        {
            var hexObj = new Hex(hex);
            Assert.Multiple(() =>
            {
                Assert.That((int)hexObj, Is.EqualTo(expected));
                Assert.That((string)hexObj, Is.EqualTo(hex));
            });
        }

        [TestCase("3308", 17, "3319")]
        [TestCase("3319", -17, "3308")]
        public void Operators_HandleAdditionAndSubtraction(string hex, int operand, string expected)
        {
            var hexObj = new Hex(hex);
            if (operand >= 0)
            {
                Assert.That((string)(hexObj + operand), Is.EqualTo(expected));
            }
            else
            {
                Assert.That((string)(hexObj - (-operand)), Is.EqualTo(expected));
            }
        }

        [TestCase("00", 0x00)]
        [TestCase("FF", 0xFF)]
        [TestCase("100", 0x00)]
        public void ByteCast_HandlesOverflow(string hex, int expected)
        {
            var hexObj = new Hex(hex);
            Assert.That((byte)hexObj, Is.EqualTo(expected));
        }
    }
}

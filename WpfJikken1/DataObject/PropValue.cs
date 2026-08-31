namespace WpfJikken1.DataObject
{
    // ROMのバイト列は6502(NES)の規約に従いリトルエンディアン(配列先頭バイトがLSB)として組み立てる。
    // ビットパターンによるマスク(同一バイトを複数フィールドが指すケース)には未対応で、
    // size=1/size>=2を問わずbyte[]全体を1つの値として読み書きする。
    public class PropValue
    {
        public byte[] Original { get; }
        public byte[] Modified { get; private set; }

        public PropValue(byte[] bytes)
        {
            Original = (byte[])bytes.Clone();
            Modified = (byte[])bytes.Clone();
        }

        public int Int
        {
            get
            {
                int value = 0;
                for (int i = 0; i < Modified.Length; i++)
                    value |= Modified[i] << (8 * i);
                return value;
            }
        }

        public bool IsModified => !Original.AsSpan().SequenceEqual(Modified);

        public void SetValue(int value)
        {
            var bytes = new byte[Modified.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)value;
                value >>= 8;
            }
            Modified = bytes;
        }
    }
}

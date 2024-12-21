namespace WpfJikken6.DataObject
{
    public class ParameterDefinition(int next)
    {
        /// <summary>
        /// アドレス
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// 名前 (Index設定時のキーも兼ねる)
        /// </summary>
        public required string Caption { get; set; }

        /// <summary>
        /// サイズ(Byte)
        /// </summary>
        public int Size { get; set; } = 1;

        /// <summary>
        /// ビット
        /// </summary>
        public string? Bit { get; set; }

        /// <summary>
        /// 間隔
        /// </summary>
        public int Next { get; set; } = next;

        /// <summary>
        /// 表示方法
        /// </summary>
        public EnmDisp Disp { get; set; } = EnmDisp.Dec;

        /// <summary>
        /// 最小値
        /// </summary>
        public string? Min { get; set; }

        /// <summary>
        /// 最大値
        /// </summary>
        public string? Max { get; set; }

        /// <summary>
        /// 項目のマスタ
        /// </summary>
        public string? Master { get; set; }

        /// <summary>
        /// 複数Byteに跨る場合の順番
        /// </summary>
        public int Index { get; set; } = 1;

        /// <summary>
        /// メモ
        /// </summary>
        public string? Memo { get; set; }
    }
}

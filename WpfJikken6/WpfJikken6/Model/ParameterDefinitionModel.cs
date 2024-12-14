namespace WpfJikken6.Model
{
    public class ParameterDefinitionModel
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
        public int Size { get; set; }

        /// <summary>
        /// マスク
        /// </summary>
        public string Mask { get; set; } = null!;

        /// <summary>
        /// 間隔
        /// </summary>
        public int Next { get; set; }

        /// <summary>
        /// 表示方法
        /// </summary>
        public EnmDisp Disp { get; set; }

        /// <summary>
        /// 最小値
        /// </summary>
        public string Min { get; set; } = null!;

        /// <summary>
        /// 最大値
        /// </summary>
        public string Max { get; set; } = null!;

        /// <summary>
        /// 項目のマスタ
        /// </summary>
        public string? Master { get; set; }

        /// <summary>
        /// 複数Byteに跨る場合の順番
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        public string? Memo { get; set; }
    }
}

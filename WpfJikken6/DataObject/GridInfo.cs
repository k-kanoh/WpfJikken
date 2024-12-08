namespace WpfJikken6.DataObject
{
    public class GridInfo
    {
        /// <summary>
        /// アドレス
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// キー()
        /// </summary>
        public required string Caption { get; set; }

        /// <summary>
        /// サイズ(Byte)
        /// </summary>
        public int Size { get; set; } = 1;

        /// <summary>
        /// フィルタ(Bit)
        /// </summary>
        public string? Filter { get; set; }

        /// <summary>
        /// 表示方法
        /// </summary>
        public EnmDisp Disp { get; set; } = EnmDisp.Dec;

        /// <summary>
        /// 最小
        /// </summary>
        public string Min { get; set; }

        /// <summary>
        /// 最大
        /// </summary>
        public string Max { get; set; }

        /// <summary>
        /// 項目のマスタ
        /// </summary>
        public string? Master { get; set; }

        /// <summary>
        /// 通番 (1起算)
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        public string? Memo { get; set; }
    }

    public enum EnmDisp
    {
        /// <summary>
        /// 非表示
        /// </summary>
        None = 0,

        /// <summary>
        /// マスタ
        /// </summary>
        List = 1,

        /// <summary>
        /// 16進数
        /// </summary>
        Hex = 16,

        /// <summary>
        /// 符号なし10進数 (0～255)
        /// </summary>
        Dec = 10,

        /// <summary>
        /// 符号付き10進数 (-128～127)
        /// </summary>
        Sin = -10
    }
}

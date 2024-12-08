namespace WpfJikken6.Model
{
    public class GridInfoModel
    {
        /// <summary>
        /// アドレス
        /// </summary>
        public required string Address { get; init; }

        /// <summary>
        /// 名前 (Index設定時のキーも兼ねる)
        /// </summary>
        public required string Caption { get; init; }

        /// <summary>
        /// サイズ(Byte)
        /// </summary>
        public int Size { get; init; } = 1;

        /// <summary>
        /// フィルタ(Bit)
        /// </summary>
        public string Filter { get; init; } = "11111111";

        /// <summary>
        /// 間隔
        /// </summary>
        public int Next { get; init; }

        /// <summary>
        /// 表示方法
        /// </summary>
        public EnmDisp Disp { get; init; } = EnmDisp.Dec;

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
        public string? Master { get; init; }

        /// <summary>
        /// 複数Byteに跨る場合の順番
        /// </summary>
        public int? Index { get; init; }

        /// <summary>
        /// メモ
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public GridInfoModel(int next)
        {
            Next = next;
        }
    }
}

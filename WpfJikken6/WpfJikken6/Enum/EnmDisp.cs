namespace WpfJikken6
{
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

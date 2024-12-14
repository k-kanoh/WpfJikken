namespace WpfJikken6.Utility
{
    /// <summary>
    /// Csv出力の列番号を設定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvFieldAttribute(int no) : Attribute
    {
        public required int FieldNo { get; init; } = no;
    }
}

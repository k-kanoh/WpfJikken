namespace WpfJikken1.Prop
{
    public class PropField
    {
        public required string Address { get; set; }
        public required string Caption { get; set; }
        public required int Size { get; set; }
        public string? BitPattern { get; set; }
        public int? Step { get; set; }
        public int? Count { get; set; }
        public required string Display { get; set; }
        public object? MinValue { get; set; }
        public object? MaxValue { get; set; }
        public string? Width { get; set; }
        public string? Memo { get; set; }
        public string? Master { get; set; }

        public int AddressValue => Convert.ToInt32(Address[2..], 16);
    }
}

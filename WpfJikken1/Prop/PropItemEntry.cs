namespace WpfJikken1.Prop
{
    public class PropItemEntry
    {
        public required string Hex { get; set; }
        public required string Name { get; set; }
    }

    public class PropItemOption
    {
        public required int Code { get; set; }
        public required string Name { get; set; }

        public string DisplayLabel => $"{Code:X2}  {Name}";

        public static PropItemOption FromEntry(PropItemEntry entry) => new() { Code = Convert.ToInt32(entry.Hex[2..], 16), Name = entry.Name };
    }
}

using WpfJikken1.DataObject;

namespace WpfJikken1.Prop
{
    public class PropItemEntry
    {
        public required Hex Hex { get; set; }
        public required string Name { get; set; }
    }

    public class PropItemOption
    {
        public required int Code { get; set; }
        public required string Name { get; set; }

        public static PropItemOption FromEntry(PropItemEntry entry) => new() { Code = entry.Hex, Name = entry.Name };
    }
}

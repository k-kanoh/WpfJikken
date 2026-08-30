using System.Text.Json;
using System.Text.Json.Serialization;

namespace WpfJikken1.DataObject
{
    [JsonConverter(typeof(HexJsonConverter))]
    public readonly struct Hex : IEquatable<Hex>
    {
        private int Value { get; }

        public Hex(int value)
        {
            Value = value;
        }

        public Hex(string text)
        {
            if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                text = text[2..];
            Value = Convert.ToInt32(text, 16);
        }

        public override string ToString() => $"0x{Value:X2}";

        public static implicit operator int(Hex hex) => hex.Value;

        public bool Equals(Hex other) => Value == other.Value;

        public override bool Equals(object? obj) => obj is Hex other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();
    }

    public class HexJsonConverter : JsonConverter<Hex>
    {
        public override Hex Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => new(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, Hex value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }
}

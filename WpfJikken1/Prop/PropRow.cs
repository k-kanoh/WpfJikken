using System.ComponentModel;

namespace WpfJikken1.Prop
{
    public class PropRow : INotifyPropertyChanged
    {
        private readonly Dictionary<string, int> _values = new();

        public required string Header { get; set; }

        // countで無効(表示対象外)になったフィールドは省いてFalseのまま。CellStyleのIsEnabledから参照する。
        public Dictionary<string, bool> FieldEnabled { get; } = new();

        public int this[string field]
        {
            get => _values.TryGetValue(field, out var v) ? v : 0;
            set
            {
                _values[field] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

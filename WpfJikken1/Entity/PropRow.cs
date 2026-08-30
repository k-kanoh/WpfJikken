using System.ComponentModel;
using WpfJikken1.DataObject;

namespace WpfJikken1.Entity
{
    public class PropRow : INotifyPropertyChanged
    {
        private readonly Dictionary<string, PropValue> _values = new();

        public required string Header { get; set; }

        // countで無効(表示対象外)になったフィールドは省いてFalseのまま。CellStyleのIsEnabledから参照する。
        public Dictionary<string, bool> FieldEnabled { get; } = new();

        public void Initialize(string field, byte[] bytes)
        {
            _values[field] = new PropValue(bytes);
        }

        public int this[string field]
        {
            get => _values.TryGetValue(field, out var v) ? v.Int : 0;
            set
            {
                _values[field].SetValue(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

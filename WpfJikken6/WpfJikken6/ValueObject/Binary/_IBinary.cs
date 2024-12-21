namespace WpfJikken6.ValueObject
{
    public interface IBinary
    {
        byte Original { get; }
        byte Modified { get; }
        BitPos BitPos { get; }

        void SetValueWithFilter(int value);

        void SetValueNoFilter(int value);
    }
}

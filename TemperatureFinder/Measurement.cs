using System;

namespace TemperatureFinder
{
    class Measurement
    {
        public Measurement(double temperature, int id)
        {
            Value = temperature;
            Id = id;
        }

        public int Id { get; }

        public double Value { get; }

        public double AbsValue { get { return Math.Abs(Value); } }

        public bool Negative { get { return Value < 0 ? true : false; } }

        public override string ToString()
        {
            return String.Format($"Pomiar nr: {Id} " + Environment.NewLine +
                $"Temperatura: {Value}°C " + Environment.NewLine +
                "----------------------");
        }
    }
}

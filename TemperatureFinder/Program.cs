using System;
using System.Collections.Generic;

namespace TemperatureFinder
{
    class Program
    {
        private static int amountOfMeasurements = 100;

        private static int minTemperature = -150;

        private static int maxTemperature = 150;

        static void Main(string[] args)
        {
            List<Measurement> measurements = GenerateMeasurements(amountOfMeasurements);

            List<Measurement> measurementsClosestToZero = FindMeasurementsClosestToZero(measurements);

            foreach (var measurement in measurements)
                Console.WriteLine(measurement.ToString());

            Console.WriteLine("Pomiary najbliższe 0: \n\r");

            foreach (var measurement in measurementsClosestToZero)
                Console.WriteLine(measurement.ToString());
        }

        private static List<Measurement> FindMeasurementsClosestToZero(List<Measurement> measurements)
        {
            double positiveTemperatureClosestToZero = maxTemperature;
            double negativeTemperatureClosestToZero = Math.Abs(minTemperature);

            foreach (var measurement in measurements)
            {
                if ((!measurement.Negative && measurement.AbsValue < positiveTemperatureClosestToZero) && measurement.AbsValue != 0)
                    positiveTemperatureClosestToZero = measurement.AbsValue;

                else if ((measurement.Negative && measurement.AbsValue < negativeTemperatureClosestToZero) && measurement.AbsValue != 0)
                    negativeTemperatureClosestToZero = measurement.AbsValue;
            }

            return measurements.FindAll(x => (x.AbsValue == positiveTemperatureClosestToZero && !x.Negative) ||
                                        (x.AbsValue == negativeTemperatureClosestToZero && x.Negative));
        }

        private static List<Measurement> GenerateMeasurements(int quantity)
        {
            List<Measurement> measurements = new List<Measurement>();

            Random random = new Random();

            for (int i = 0; i < quantity; i++)
            {
                double temperature = Math.Round((random.NextDouble() *
                    (maxTemperature - minTemperature) + minTemperature), 2, MidpointRounding.AwayFromZero);

                var measurement = new Measurement(temperature, measurements.Count);

                measurements.Add(measurement);
            }

            return measurements;
        }
    }
}

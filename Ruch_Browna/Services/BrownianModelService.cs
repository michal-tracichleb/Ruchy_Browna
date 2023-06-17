using System.Globalization;
using Ruch_Browna.Models;

namespace Ruch_Browna.Services
{
    public class BrownianModelService
    {
        public BrownianModelService() { }

        private static int _id = 0;
        private static List<BrownianMotionSimulationView> _simulationViews = new List<BrownianMotionSimulationView>();

        public static BrownianMotionSimulationView GenerateBrownianModel(int amountOfSteps)
        {
            var format = new NumberFormatInfo();
            format.NumberDecimalSeparator = ".";

            var vectorLength = 1;

            var result = new BrownianMotionSimulationView
            {
                AmountOfSteps = amountOfSteps,
                CreatDateTime = DateTime.Now,
                Vector = 0,
                Coordinates = new List<CoordinateView>
                {
                    new CoordinateView
                    {
                        Step = 0,
                        ValueX = 0,
                        ValueY = 0,
                        Vector = 0
                    },
                }
            };

            string chartCoordinates = "[0, 0],";

            for (int i = 0; i < amountOfSteps; i++)
            {
                var vectorAangle = GenerateRandomDouble(2 * Math.PI);

                var x = result.Coordinates[i].ValueX + (vectorLength * Math.Cos(vectorAangle));
                var y = result.Coordinates[i].ValueY + (vectorLength * Math.Sin(vectorAangle));

                result.Coordinates.Add(
                    new CoordinateView
                    {
                        Step = i + 1,
                        ValueX = x,
                        ValueY = y,
                        Vector = Math.Sqrt((x * x) + (y * y))
                    });

                chartCoordinates += "[" + x.ToString("#0.00000", format) + ", ";
                chartCoordinates += y.ToString("#0.00000", format) + "]" + ",";

                Thread.Sleep(1);
            }

            if (!string.IsNullOrEmpty(chartCoordinates))
            {
                chartCoordinates = chartCoordinates.Remove(chartCoordinates.Length - 1, 1);
            }

            result.Vector = result.Coordinates[amountOfSteps].Vector;
            result.ChartCoordinates = chartCoordinates;

            result.Id = NextId();
            _simulationViews.Add(result);

            return result;
        }

        private static double GenerateRandomDouble(double max)
        {
            var random = new Random();
            double result = random.NextDouble() * max;
            return result;
        }

        private static int NextId()
        {
            _id += 1;
            return _id;
        }
    }
}
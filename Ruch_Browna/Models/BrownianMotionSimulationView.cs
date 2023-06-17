using System.ComponentModel.DataAnnotations;

namespace Ruch_Browna.Models
{
    public class BrownianMotionSimulationView
    {
        public int Id { get; set; }

        [Display(Name = "Liczba kroków")]
        public int AmountOfSteps { get; set; }

        public List<CoordinateView> Coordinates { get; set; }

        [Display(Name = "Wektor przesunięcia")]
        public double Vector { get; set; }

        public DateTime CreatDateTime { get; set; }

        public string ChartCoordinates { get; set; }
    }
}

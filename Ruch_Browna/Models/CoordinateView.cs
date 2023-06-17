using System.ComponentModel.DataAnnotations;

namespace Ruch_Browna.Models
{
    public class CoordinateView
    {
        [Display(Name = "Krok")]
        public int Step { get; set; }
        [Display(Name = "Wsp. X")]
        public double ValueX { get; set; }
        [Display(Name = "Wsp. Y")]
        public double ValueY { get; set; }
        [Display(Name = "Wektor")]
        public double Vector { get; set; }
    }
}

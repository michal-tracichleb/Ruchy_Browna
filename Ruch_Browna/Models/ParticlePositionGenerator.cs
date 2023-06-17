using System.ComponentModel.DataAnnotations;

namespace Ruch_Browna.Models
{
    public class ParticlePositionGenerator
    {
        [Display(Name = "Liczba kroków")]
        [Required(ErrorMessage = "Proszę wprowadzić ilość kroków, dla cząsteczki")]
        [Range(1, 1000, ErrorMessage = "Proszę wprowadź watość od 1 do 1 000")]
        public int AmountOfSteps { get; set; }
    }
}

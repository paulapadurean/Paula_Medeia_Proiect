using System.ComponentModel.DataAnnotations;

namespace Paula_Medeia_Proiect.Models
{
    public class StylistSpecialization
    {
        public int ID { get; set; }

        [Display(Name = "Specialization Name")]
        public string Name { get; set; }

        public ICollection<Stylist>? Stylists { get; set; } 
    }
}

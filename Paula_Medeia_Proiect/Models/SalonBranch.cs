using System.ComponentModel.DataAnnotations;

namespace Paula_Medeia_Proiect.Models
{
    public class SalonBranch
    {
        public int ID { get; set; }

        [Display(Name = "Salon Branch Name")]
        public string BranchName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public ICollection<Service>? Services { get; set; } 
    }
}

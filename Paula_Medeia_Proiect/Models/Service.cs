using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paula_Medeia_Proiect.Models
{
    public class Service
    {

        public int ID { get; set; }

        [Display(Name = "Service Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public DateTime ServiceDate { get; set; } 

        public int? SalonBranchID { get; set; }
        public SalonBranch? SalonBranch { get; set; }

        public int? StylistID { get; set; }
        public Stylist? Stylist { get; set; }
        public ICollection<Booking>? Bookings { get; set; }


    }
}

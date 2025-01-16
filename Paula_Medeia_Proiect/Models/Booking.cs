using System.ComponentModel.DataAnnotations;

namespace Paula_Medeia_Proiect.Models
{
    public class Booking
    {
        public int ID { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        public int? ServiceID { get; set; }
        public Service? Service { get; set; }

        [Required(ErrorMessage = "Data rezervării este obligatorie.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
    }
}

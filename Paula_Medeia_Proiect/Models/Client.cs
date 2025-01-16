using System.ComponentModel.DataAnnotations;

namespace Paula_Medeia_Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$",
        ErrorMessage = "Prenumele trebuie să înceapă cu majusculă (ex. Ana sau Ana-Maria).")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Prenumele trebuie să aibă între 3 și 30 de caractere.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s-]*$",
          ErrorMessage = "Numele trebuie să înceapă cu majusculă.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Numele trebuie să aibă între 3 și 30 de caractere.")]
        public string? LastName { get; set; }


        [StringLength(70, ErrorMessage = "Adresa poate avea maxim 70 de caractere.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Email-ul este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Email-ul nu este valid.")]
        public string Email { get; set; }

        [RegularExpression(@"^0[0-9]{3}[-. ]?[0-9]{3}[-. ]?[0-9]{3}$",
         ErrorMessage = "Telefonul trebuie să fie de forma '0722-123-123', '0722.123.123' sau '0722 123 123'.")]
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Booking>? Bookings { get; set; }
    }
}

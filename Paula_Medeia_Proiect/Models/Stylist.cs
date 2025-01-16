namespace Paula_Medeia_Proiect.Models
{
    public class Stylist
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Service>? Services { get; set; }
        public int? StylistSpecializationID { get; set; }
        public StylistSpecialization? StylistSpecialization { get; set; }
    }
}

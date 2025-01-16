using System.Collections.Generic;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.ViewModels
{
    public class SalonBranchIndexData
    {
        public IEnumerable<SalonBranch> SalonBranches { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}

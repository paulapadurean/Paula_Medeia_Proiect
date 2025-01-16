using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Data
{
    public class Paula_Medeia_ProiectContext : DbContext
    {
        public Paula_Medeia_ProiectContext (DbContextOptions<Paula_Medeia_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Paula_Medeia_Proiect.Models.Service> Service { get; set; } = default!;
        public DbSet<Paula_Medeia_Proiect.Models.SalonBranch> SalonBranch { get; set; } = default!;
        public DbSet<Paula_Medeia_Proiect.Models.Stylist> Stylist { get; set; } = default!;
        public DbSet<Paula_Medeia_Proiect.Models.StylistSpecialization> StylistSpecialization { get; set; } = default!;
        public DbSet<Paula_Medeia_Proiect.Models.Client> Client { get; set; } = default!;
        public DbSet<Paula_Medeia_Proiect.Models.Booking> Booking { get; set; } = default!;
        public IEnumerable Stylists { get; internal set; }
        public IEnumerable SalonBranches { get; internal set; }
    }
}

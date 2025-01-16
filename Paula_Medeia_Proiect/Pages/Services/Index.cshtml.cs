using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly Paula_Medeia_ProiectContext _context;

        public IndexModel(Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get; set; } = default!;

      
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
         
            var servicesQuery = _context.Service
                                        .Include(s => s.SalonBranch)
                                        .Include(s => s.Stylist)
                                        .AsQueryable();

          
            if (!string.IsNullOrEmpty(SearchString))
            {
                servicesQuery = servicesQuery.Where(s =>
                    s.Name.ToLower().Contains(SearchString.ToLower()));
            }

            
            Service = await servicesQuery.AsNoTracking().ToListAsync();
        }
    }
}

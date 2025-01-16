using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Pages.StylistSpecializations
{
    public class DetailsModel : PageModel
    {
        private readonly Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext _context;

        public DetailsModel(Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        public StylistSpecialization StylistSpecialization { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stylistspecialization = await _context.StylistSpecialization.FirstOrDefaultAsync(m => m.ID == id);
            if (stylistspecialization == null)
            {
                return NotFound();
            }
            else
            {
                StylistSpecialization = stylistspecialization;
            }
            return Page();
        }
    }
}

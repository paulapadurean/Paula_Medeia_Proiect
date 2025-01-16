using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;
using System.Threading.Tasks;

namespace Paula_Medeia_Proiect.Pages.Stylists
{
    public class DetailsModel : PageModel
    {
        private readonly Paula_Medeia_ProiectContext _context;

        public DetailsModel(Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        public Stylist Stylist { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
           
            Stylist = await _context.Stylist
                                    .Include(s => s.StylistSpecialization) 
                                    .FirstOrDefaultAsync(m => m.ID == id);

            if (Stylist == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}


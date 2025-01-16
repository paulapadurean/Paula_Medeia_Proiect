using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Pages.Stylists
{
    public class CreateModel : PageModel
    {
        private readonly Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext _context;

        public CreateModel(Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StylistSpecializationID"] = new SelectList(_context.StylistSpecialization, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Stylist Stylist { get; set; } = default!;

     
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["StylistSpecializationID"] = new SelectList(_context.StylistSpecialization, "ID", "Name");
                return Page();
            }

            _context.Stylist.Add(Stylist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

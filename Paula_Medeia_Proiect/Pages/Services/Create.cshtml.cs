using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Pages.Services
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
            
            ViewData["SalonBranchID"] = new SelectList(_context.SalonBranch, "ID", "BranchName");

          
            ViewData["StylistID"] = new SelectList(
                _context.Stylist.Select(s => new { s.ID, FullName = s.FirstName + " " + s.LastName }),
                "ID",
                "FullName"
            );

            return Page();
        }


        [BindProperty]
        public Service Service { get; set; } = default!;

      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               
                ViewData["SalonBranchesID"] = new SelectList(_context.SalonBranch, "ID", "BranchName");

                ViewData["StylistsID"] = new SelectList(
                    _context.Stylist.Select(s => new { s.ID, FullName = s.FirstName + " " + s.LastName }),
                    "ID",
                    "FullName"
                );
            }

            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Pages.Bookings
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext _context;

        public EditModel(Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking =  await _context.Booking.FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
           ViewData["ServiceID"] = new SelectList(_context.Service, "ID", "ID");
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID == id);
        }
    }
}

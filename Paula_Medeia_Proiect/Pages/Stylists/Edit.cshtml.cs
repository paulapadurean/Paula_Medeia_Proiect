﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Pages.Stylists
{
    public class EditModel : PageModel
    {
        private readonly Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext _context;

        public EditModel(Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stylist Stylist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stylist = await _context.Stylist
                .Include(s => s.StylistSpecialization)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Stylist == null)
            {
                return NotFound();
            }

            ViewData["StylistSpecializationID"] = new SelectList(_context.StylistSpecialization, "ID", "Name");
            return Page();
        }


       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StylistExists(Stylist.ID))
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

        private bool StylistExists(int id)
        {
            return _context.Stylist.Any(e => e.ID == id);
        }
    }
}
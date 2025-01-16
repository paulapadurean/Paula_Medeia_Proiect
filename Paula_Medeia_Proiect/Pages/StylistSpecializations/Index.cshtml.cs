﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext _context;

        public IndexModel(Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        public IList<StylistSpecialization> StylistSpecialization { get;set; } = default!;

        public async Task OnGetAsync()
        {
            StylistSpecialization = await _context.StylistSpecialization.ToListAsync();
        }
    }
}
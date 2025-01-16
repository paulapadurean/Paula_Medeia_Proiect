using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;

namespace Paula_Medeia_Proiect.Pages.Clients
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext _context;

        public IndexModel(Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Client.ToListAsync();
        }
    }
}

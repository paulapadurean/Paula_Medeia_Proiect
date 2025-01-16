using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paula_Medeia_Proiect.Data;
using Paula_Medeia_Proiect.Models;
using Paula_Medeia_Proiect.ViewModels;

namespace Paula_Medeia_Proiect.Pages.SalonBranches
{
    public class IndexModel : PageModel
    {
        private readonly Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext _context;

        public IndexModel(Paula_Medeia_Proiect.Data.Paula_Medeia_ProiectContext context)
        {
            _context = context;
        }

        public IList<SalonBranch> SalonBranch { get; set; } = default!;

        public SalonBranchIndexData SalonBranchData { get; set; }
        public int SalonBranchID { get; set; }
        public int ServiceID { get; set; }


        public async Task OnGetAsync(int? id, int? serviceID)
        {
            SalonBranchData = new SalonBranchIndexData();
            SalonBranchData.SalonBranches = await _context.SalonBranch
                .Include(sb => sb.Services)
                .OrderBy(sb => sb.BranchName)
                .ToListAsync();

            if (id != null)
            {
                SalonBranchID = id.Value;
                SalonBranch salonBranch = SalonBranchData.SalonBranches
                    .Where(sb => sb.ID == id.Value).Single();
                SalonBranchData.Services = salonBranch.Services;
            }
        }
    }
}

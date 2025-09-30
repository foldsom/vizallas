using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vizallas.Data;
using vizallas.Models;

namespace vizallas.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly vizallas.Data.VizallasContext _context;

        public DetailsModel(vizallas.Data.VizallasContext context)
        {
            _context = context;
        }

        public Vizallas Vizallas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizallas = await _context.Vizallas.FirstOrDefaultAsync(m => m.Id == id);
            if (vizallas == null)
            {
                return NotFound();
            }
            else
            {
                Vizallas = vizallas;
            }
            return Page();
        }
    }
}

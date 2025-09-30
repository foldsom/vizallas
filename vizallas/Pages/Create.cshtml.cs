using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using vizallas.Data;
using vizallas.Models;

namespace vizallas.Pages
{
    public class CreateModel : PageModel
    {
        private readonly vizallas.Data.VizallasContext _context;

        public CreateModel(vizallas.Data.VizallasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vizallas Vizallas { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vizallas.Add(Vizallas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

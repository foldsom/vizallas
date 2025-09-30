using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vizallas.Data;
using vizallas.Models;

namespace vizallas.Pages
{
    public class EditModel : PageModel
    {
        private readonly vizallas.Data.VizallasContext _context;

        public EditModel(vizallas.Data.VizallasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vizallas Vizallas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizallas =  await _context.Vizallas.FirstOrDefaultAsync(m => m.Id == id);
            if (vizallas == null)
            {
                return NotFound();
            }
            Vizallas = vizallas;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vizallas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VizallasExists(Vizallas.Id))
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

        private bool VizallasExists(int id)
        {
            return _context.Vizallas.Any(e => e.Id == id);
        }
    }
}

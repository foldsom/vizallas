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
    public class IndexModel : PageModel
    {
        private readonly vizallas.Data.VizallasContext _context;

        public IndexModel(vizallas.Data.VizallasContext context)
        {
            _context = context;
        }

        public IList<Vizallas> Vizallas { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vizallas = await _context.Vizallas.ToListAsync();
        }
    }
}

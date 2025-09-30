using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vizallas.Data;
using vizallas.Models;

namespace vizallas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VizallasContext _context;
        public IndexModel(VizallasContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public string? Folyo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Varos { get; set; }

        public List<string> Folyok { get; set; } = new();
        public List<string> Varosok { get; set; } = new();

        public IList<Vizallas> VizallasLista { get; set; } = new List<Vizallas>();

        public async Task OnGetAsync()
        {
            Folyok = await _context.Vizallas
                .Select(x => x.Folyo)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            Varosok = await _context.Vizallas
                .Select(x => x.Varos)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            var q = _context.Vizallas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Folyo))
                q = q.Where(x => x.Folyo == Folyo);

            if (!string.IsNullOrWhiteSpace(Varos))
                q = q.Where(x => x.Varos == Varos);

            VizallasLista = await q
                .OrderBy(x => x.Varos)
                .ThenBy(x => x.Datum)
                .ToListAsync();
        }
    }
}

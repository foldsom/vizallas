using Microsoft.EntityFrameworkCore;
using vizallas.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// ABSZOLÚT útvonalra alakítjuk, így biztosan oda készül a fájl:
var cs = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Vizallas.db";
var dbPath = cs.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase)
    ? $"Data Source={Path.Combine(builder.Environment.ContentRootPath, cs.Substring("Data Source=".Length))}"
    : cs;

builder.Services.AddDbContext<VizallasContext>(o => o.UseSqlite(dbPath));

var app = builder.Build();

// **VAGY** migráció, **VAGY** EnsureCreated – NE együtt! (ajánlott a migráció)
using (var scope = app.Services.CreateScope())
{
    db.Database.Migrate();           // ha akarsz migrációt
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();

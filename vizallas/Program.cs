using Microsoft.EntityFrameworkCore;
using vizallas.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// ABSZOL�T �tvonalra alak�tjuk, �gy biztosan oda k�sz�l a f�jl:
var cs = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Vizallas.db";
var dbPath = cs.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase)
    ? $"Data Source={Path.Combine(builder.Environment.ContentRootPath, cs.Substring("Data Source=".Length))}"
    : cs;

builder.Services.AddDbContext<VizallasContext>(o => o.UseSqlite(dbPath));

var app = builder.Build();

// **VAGY** migr�ci�, **VAGY** EnsureCreated � NE egy�tt! (aj�nlott a migr�ci�)
using (var scope = app.Services.CreateScope())
{
    db.Database.Migrate();           // ha akarsz migr�ci�t
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();

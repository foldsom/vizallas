using Microsoft.EntityFrameworkCore;
using vizallas.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var cs = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Vizallas.db";
if (cs.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
{
    var file = cs.Substring("Data Source=".Length).Trim();
    var abs = Path.Combine(builder.Environment.ContentRootPath, file);
    cs = $"Data Source={abs}";
}
builder.Services.AddDbContext<VizallasContext>(o => o.UseSqlite(cs));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VizallasContext>();
    db.Database.Migrate();
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();

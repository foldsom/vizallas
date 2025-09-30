using vizallas.Models; 
using Microsoft.EntityFrameworkCore;
using vizallas.Data;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);


var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Vizallas.db");
builder.Services.AddDbContext<VizallasContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VizallasContext>();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
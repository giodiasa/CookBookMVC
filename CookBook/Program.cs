using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CookBook.Areas.Identity.Data;
using CookBook.Interfaces;
using CookBook.Services;
using CookBook.Models;
using CookBook.Mapping;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CookBookDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CookBookDbContextConnection' not found.");

builder.Services.AddDbContext<CookBookDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CookBookUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<CookBookDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IMapper<CookBook.Entities.Recipe, RecipeModel>, RecipeMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

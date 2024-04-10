using CoreWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IFriendRepository, FriendRepository>();

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").GetSection("ConnectionSQL").Value;
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionStrings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

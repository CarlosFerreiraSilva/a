using CoderCarrer.Context;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<Contexto>
(options => options.UseMySql(
        "server=localhost;Port=3306;initial catalog=projeto_crawler;uid=root;pwd=123456",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql")));

//"server=localhost; port = 3306; database = projeto_crawler; user = root; password = 123456; Persist Security Info=False; Connect Timeout = 300",
builder.Services.AddControllersWithViews();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

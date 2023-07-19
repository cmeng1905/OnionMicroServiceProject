using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnionProject.WebMvc.Extensions;
using OnionProject.WebMvc.Models;
using OnionProject.WebMvc.Models.Account;
using OnionProject.WebMvc.Services.Abstractions;
using OnionProject.WebMvc.Services.Concrete;
using OnionProject.WebMvc.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>();
});

builder.Services.AddHttpClientServices(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "OnionProjectCookie";
                    options.Cookie.Path = "/";
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Forbidden/");
                    options.ExpireTimeSpan = new TimeSpan(5, 0, 0, 0);
                    options.SlidingExpiration = true;
                    options.LogoutPath = new PathString("/Account/Logout");
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

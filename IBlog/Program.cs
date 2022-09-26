
using FluentValidation.AspNetCore;
using IBlog.Business.AutoMapper;
using IBlog.Business.IoC;
using IBlog.Business.Validators.Blog;
using IBlog.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<IBlogContext>();
builder.Services.IocService();
builder.Services.AddAutoMapper(typeof(AutoProfile));
builder.Services.AddControllersWithViews().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<BlogsValidator>());

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(s =>
{
    s.LoginPath = "/Login";
    s.LogoutPath = "/Login/Logout";
    s.AccessDeniedPath = "/YetkisizGiris";
});

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=home}/{action=Index}/{id?}"
    );
});


app.Run();

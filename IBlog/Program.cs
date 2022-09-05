using IBlog.Business.Abstract;
using IBlog.Business.AutoMapper;
using IBlog.Business.Concrete;
using IBlog.Business.EmailService;
using IBlog.Business.UserManager;
using IBlog.DataAccess;
using IBlog.DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<IBlogContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBlogsService, BlogsService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IImagesService, ImagesService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddAutoMapper(typeof(AutoProfile));
builder.Services.AddControllersWithViews();

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

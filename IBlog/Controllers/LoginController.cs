using IBlog.Business.Abstract;
using IBlog.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IBlog.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersService usersService;

        public LoginController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            var user = usersService.LoginAsync(email, password).Result;
            if (user != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("Id", user.Id.ToString()));
                claims.Add(new Claim("NameSurnameFirstChar", user.Name.Substring(0,1) + user.Surname.Substring(0,1)));
                claims.Add(new Claim("AvatarImage", user.AvatarImage ?? ""));
                claims.Add(new Claim(ClaimTypes.Name, user.Name + " " + user.Surname));
                if (user.RoleType == 1)
                    claims.Add(new Claim(ClaimTypes.Role, "Yönetici"));
                else
                    claims.Add(new Claim(ClaimTypes.Role, "Yazar"));

                var userIdentity = new ClaimsIdentity(claims, "UserInfo");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                var cookiesTime = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddDays(1),
                    IsPersistent = true,
                };
                HttpContext.SignInAsync(principal, cookiesTime);
                return Redirect("/panel/Home/Index");
            }
            else
            {
                ViewBag.Message = "Böyle Bir Kullanıcı Bulunamadı.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users customer)
        {
            var result = usersService.AddAsync(customer).Result;
            if (result.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
                return Redirect("/login/Index");
            else
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }
    }
}

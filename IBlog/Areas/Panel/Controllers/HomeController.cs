using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class HomeController : Controller
    {

        private readonly IUsersService _usersService;

        public HomeController( IUsersService usersService)
        {      
            _usersService = usersService;
        }

        public IActionResult Index()
        {       
            ViewBag.Title = "Kategori";
            return View();
        }
    }
}

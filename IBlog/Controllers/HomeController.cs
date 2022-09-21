using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogsService blogsService;
        private readonly IUsersService _usersService;

        public HomeController(IBlogsService blogsService, IUsersService usersService)
        {
            this.blogsService = blogsService;
            _usersService = usersService;
        }

        public IActionResult Index()
        {
            _usersService.UserControl();
            ViewBag.Title = "Ana Sayfa";
            var dataList = blogsService.GetAllBlogsActiveAsync().Result;
            return View(dataList);
        }
    }
}

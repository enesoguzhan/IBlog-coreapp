using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogsService blogsService;
        public HomeController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;       
        }

        public IActionResult Index()
        {        
            ViewBag.Title = "Ana Sayfa";
            var dataList = blogsService.GetAllBlogsActiveAsync().Result;
            return View(dataList);
        }
    }
}

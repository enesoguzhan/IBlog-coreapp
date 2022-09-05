using IBlog.Business.Abstract;
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
            var dataList = blogsService.GetAllBlogsAsync().Result; 
            return View(dataList);
        }
    }
}

using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogsService blogsService;

        public BlogsController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("/blogs/detail/{id}")]
        public IActionResult Detail(Guid id)
        {
            ViewBag.Title = "Blog Detay";
            var data = blogsService.GetBlogAllInclude(id).Result;
            return View(data);
        }
    }
}

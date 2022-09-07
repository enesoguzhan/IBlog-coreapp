using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogsService blogsService;
        private readonly IUserManager _userManager;

        public BlogsController(IBlogsService blogsService, IUserManager userManager)
        {
            this.blogsService = blogsService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("/blogs/detail/{id}")]
        public IActionResult Detail(Guid id)
        {
            ViewBag.UserInfo = _userManager.GetUserClaims();
            ViewBag.Title = "Blog Detay";
            var data = blogsService.GetBlogAllInclude(id).Result;
            return View(data);
        }

        [HttpGet]
        [Route("/blogs/getcategoryblogs/{id:Guid}")]
        public IActionResult GetCategoryBlogs(Guid id)
        {
            var data = blogsService.GetAllBlogsGetByCategoriesAsync(id).Result;
            ViewBag.Title = $"{data.First().Categories.Name} Blogları";
            return View(data);
        }
    }
}

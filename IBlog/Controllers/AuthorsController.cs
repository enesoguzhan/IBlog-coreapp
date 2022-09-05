using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IUsersService _usersService;

        public AuthorsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("/authors/{id:Guid}")]
        public IActionResult Index(Guid id)
        {
            ViewBag.Title = "Yazar Hakkında";
            var data = _usersService.GetAuthorsBlogs(id).Result;
            return View(data);
        }


    }

}

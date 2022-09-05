using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Controllers
{
    public class CategoriesController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        }

      
    }
}

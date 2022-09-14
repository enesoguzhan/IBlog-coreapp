using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Yorumlar";
            return View();
        }
    }
}

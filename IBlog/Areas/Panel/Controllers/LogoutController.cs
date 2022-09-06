using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            TempData["Message"] = "Başarılı Şekilde Çıkış Yapıldı";
            return Redirect("/login/Index");
        }
    }
}

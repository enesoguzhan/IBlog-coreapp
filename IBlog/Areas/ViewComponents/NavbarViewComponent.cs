using IBlog.Business.UserManager;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.ViewComponents
{
    [Area("Panel")]
    public class NavbarViewComponent : ViewComponent
    {
        private readonly IUserManager userManager;

        public NavbarViewComponent(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.UserInfo = userManager.GetUserClaims();
            return View();
        }
    }
}

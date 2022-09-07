using IBlog.Business.UserManager;
using IBlog.Entities.DTO.UserManeger;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.ViewComponents
{
    public class GetHeaderNavbarViewComponent : ViewComponent
    {
        private readonly IUserManager _userManager;

        public GetHeaderNavbarViewComponent(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            UserClaims data =_userManager.GetUserClaims();
            return View(data);
        }
    }
}

using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.ViewComponents
{
    public class NewUserViewComponent : ViewComponent
    {
        private readonly IUsersService _usersService;

        public NewUserViewComponent(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_usersService.NewUsers().Result);
        }
    }
}

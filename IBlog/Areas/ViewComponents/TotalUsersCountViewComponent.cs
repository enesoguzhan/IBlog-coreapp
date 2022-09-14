using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.ViewComponents
{
    public class TotalUsersCountViewComponent : ViewComponent
    {
        private readonly IUsersService _usersService;

        public TotalUsersCountViewComponent(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_usersService.TotalUsersCount().Result);
        }
    }
}

using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.ViewComponents
{
    public class TotalBlogsCountViewComponent : ViewComponent
    {
        private readonly IBlogsService _blogsService;

        public TotalBlogsCountViewComponent(IBlogsService blogsService)
        {
            _blogsService = blogsService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_blogsService.TotalBlogsCount().Result);
        }
    }
}

using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.ViewComponents
{
    public class LastAddedBlogsViewComponent : ViewComponent
    {
        private readonly IBlogsService _blogsService;

        public LastAddedBlogsViewComponent(IBlogsService blogsService)
        {
            _blogsService = blogsService;
        }

        public IViewComponentResult Invoke()
        {
            var data = _blogsService.GetLastAddedBlogs().Result;
            return View(data);
        }
    }
}

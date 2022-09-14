using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.ViewComponents
{
    public class LastAddedBlogViewComponent : ViewComponent
    {
        private readonly IBlogsService _blogsService;

        public LastAddedBlogViewComponent(IBlogsService blogsService)
        {
            _blogsService = blogsService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_blogsService.LastAddedBlog().Result);
        }
    }
}

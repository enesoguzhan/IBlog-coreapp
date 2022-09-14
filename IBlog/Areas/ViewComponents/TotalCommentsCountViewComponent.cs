using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.ViewComponents
{
    public class TotalCommentsCountViewComponent : ViewComponent
    {
        private readonly ICommentsService _commentsService;

        public TotalCommentsCountViewComponent(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        public IViewComponentResult Invoke()
        {

            return View(_commentsService.TotalCommentsCount().Result);
        }
    }
}

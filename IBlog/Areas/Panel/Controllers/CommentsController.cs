using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        [Route("/panel/comments/Index/{BlogId:Guid}")]
        public IActionResult Index(Guid BlogId)
        {
            ViewBag.Title = "Yorumlar";
            return View(_commentsService.GetCommentsByBlog(BlogId).Result);
        }
    }
}

using IBlog.Business.Abstract;
using IBlog.Entities.DTO.Comments;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InsertComment(CommentsInsertDTO commentsInsertDTO)
        {
            TempData["Message"] = _commentsService.AddAsync(commentsInsertDTO).Result.Message;
            return Redirect($"/blogs/detail/{commentsInsertDTO.BlogId}");
        }
    }
}

using IBlog.Business.Abstract;
using IBlog.Entities;
using IBlog.UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class ImagesController : Controller
    {
        private readonly IImagesService _imagesService;

        public ImagesController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpGet]
        [Route("/panel/Images/Index/{BlogId}")]
        public IActionResult Index(Guid BlogId)
        {
            IList<Images> data = _imagesService.GetImagesByBlogIdAsync(BlogId).Result;
            return View(data);
        }

        [HttpGet]
        [Route("/panel/Images/Delete/{Id}/{name}/{blogId}")]
        public IActionResult Delete(Guid Id, string name,Guid blogId)
        {
            var result = _imagesService.DeleteAsync(Id).Result;
            if (result.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                ImagesUploader.DeleteImage(name);

            }
            return Redirect($"/panel/Images/Index/{blogId}");
        }
    }
}

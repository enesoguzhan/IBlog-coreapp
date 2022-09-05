using IBlog.Business.Abstract;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class BlogsController : Controller
    {
        private readonly IBlogsService blogsService;
        private readonly IImagesService imagesService;
        private readonly ICategoriesService categoriesService;


        public BlogsController(IBlogsService blogsService, IImagesService imagesService, ICategoriesService categoriesService)
        {
            this.blogsService = blogsService;
            this.imagesService = imagesService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Blog Listesi";
            return View(blogsService.GetAllBlogsAsync().Result);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Title = "Blog Oluştur";
            ViewBag.Categories = categoriesService.GetAllCategoriesAsync().Result;

            return View();
        }

        [HttpPost]
        public IActionResult Insert(Blogs blogs, IList<IFormFile> images)
        {
            ViewBag.Title = "Blog Oluştur";
            string imageName = string.Empty;
            ViewBag.Message = blogsService.AddAsync(blogs).Result;
            foreach (var item in images)
            {
                imageName = Helpers.ImagesUploader.UploadImage(item);
                if (imageName == "0")
                {
                    ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
                }
                else if (imageName == "1")
                {
                    ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
                }
                else if (!string.IsNullOrEmpty(imageName))
                {
                    imagesService.AddAsync(imageName, blogs.Id);
                }
            }

            return View();
        }

        [Route("/Panel/Blogs/Update/{id:Guid}")]
        public IActionResult Update(Guid id)
        {
            ViewBag.Title = "Blog Güncelle";
            ViewBag.Categories = categoriesService.GetAllCategoriesAsync().Result;
            return View(blogsService.GetBlogAllInclude(id).Result);
        }

        [HttpPost]
        [Route("/panel/blogs/Update/{id:Guid}")]
        public IActionResult Update(Guid id, BlogsUpdateDTO blogs)
        {
            ViewBag.Title = "Blog Güncelle";
            ViewBag.Categories = categoriesService.GetAllCategoriesAsync().Result;
            blogs.Id = id;               
            ViewBag.Message = blogsService.UpdateAsync(blogs).Result;
            return View(blogsService.GetBlog(id).Result);
        }

    }
}

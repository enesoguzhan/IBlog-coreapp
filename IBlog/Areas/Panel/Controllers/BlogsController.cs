using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.UserManeger;
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
        private readonly IUserManager userManager;
        public BlogsController(IBlogsService blogsService, IImagesService imagesService, ICategoriesService categoriesService, IUserManager userManager)
        {
            this.blogsService = blogsService;
            this.imagesService = imagesService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;

        }

        public IActionResult Index()
        {
            UserClaims userClaims = userManager.GetUserClaims();
            if (userClaims.Role == "Yönetici")
            {
                ViewBag.Title = "Blog Listesi";
                return View(blogsService.GetListBlog().Result);
            }
            else
                return Redirect($"/panel/blogs/UserBlogsList/{userClaims.Id}");

        }

        [HttpGet]
        [Route("/panel/blogs/UserBlogsList/{id:Guid}")]
        public IActionResult UserBlogsList(Guid id)
        {
            ViewBag.Title = "Bloglarım";
            return View(blogsService.GetListBlogByUser(id).Result);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Title = "Blog Oluştur";
            ViewBag.Categories = categoriesService.GetAllCategoriesAsync().Result;

            return View();
        }

        [HttpPost]
        public IActionResult Insert(BlogsInsertDTO blogs, IList<IFormFile> images)
        {
            ViewBag.Title = "Blog Oluştur";

            if (ModelState.IsValid)
            {
                string imageName = string.Empty;
                TempData["Message"] = blogsService.AddAsync(blogs).Result.Message;
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
                return Redirect("/panel/blogs/Index");
            }
            else
            {
                ViewBag.Categories = categoriesService.GetAllCategoriesAsync().Result;
                return View();
            }
        }

        [Route("/Panel/Blogs/Update/{id:Guid}")]
        public IActionResult Update(Guid id)
        {
            ViewBag.Title = "Blog Güncelle";
            ViewBag.Categories = categoriesService.GetAllCategoriesAsync().Result;
            return View(blogsService.GetUpdateBlogs(id).Result);
        }

        [HttpPost]
        [Route("/panel/blogs/Update/{id:Guid}")]
        public IActionResult Update(Guid id, BlogsUpdateDTO blogs, IList<IFormFile> images)
        {
            var userClaims = userManager.GetUserClaims();
            ViewBag.Title = "Blog Güncelle";
            ViewBag.Categories = categoriesService.GetAllCategoriesAsync().Result;
            if (ModelState.IsValid)
            {
                string imageName = string.Empty;
                blogs.Id = id;
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
                var result = blogsService.UpdateAsync(blogs).Result;
                if (result.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
                {
                    TempData["Message"] = result.Message;

                    return View(blogsService.GetUpdateBlogs(id).Result);
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View(blogsService.GetUpdateBlogs(id).Result);
                }
            }
            else
            {
                return View(blogsService.GetUpdateBlogs(id).Result);
            }
        }

        [HttpGet]
        [Route("/panel/blogs/Delete/{Id:Guid}")]
        public IActionResult Delete(Guid Id)
        {
            var result = blogsService.DeleteAsync(Id).Result;
            TempData["Message"] = result.Message;
            return Redirect("/panel/blogs/Index");


        }
    }
}

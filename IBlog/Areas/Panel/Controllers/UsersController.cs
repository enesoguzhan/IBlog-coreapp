using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class UsersController : Controller
    {
        readonly IUsersService usersService;
        readonly IUserManager userManager;

        public UsersController(IUsersService usersService, IUserManager userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("/Panel/Users/Index/{id:Guid}")]
        public IActionResult Index(Guid id)
        {
            ViewBag.Title = "Profil Güncelle";
            return View(usersService.GetUser(id).Result);
        }

        [HttpPost]
        [Route("/panel/users/Index/{id:Guid}")]
        public IActionResult Index(Guid id, Users users, IList<IFormFile> AvatarImage)
        {
            ViewBag.Title = "Profil Güncelle";
            string imageName = string.Empty;

            foreach (var item in AvatarImage)
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
                    users.AvatarImage = imageName;
                    userManager.UserAvatarImages(imageName);
                }
            }

            ViewBag.Message = usersService.UpdateAsync(id, users).Result;
            return View(usersService.GetUser(id).Result);
        }
    }
}

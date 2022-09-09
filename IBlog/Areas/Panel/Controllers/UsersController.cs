using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Entities;
using IBlog.Entities.DTO.Users;
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
                    return View(usersService.GetUser(id).Result);

                }
                else if (imageName == "1")
                {
                    ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
                    return View(usersService.GetUser(id).Result);
                }
                else if (!string.IsNullOrEmpty(imageName))
                {
                    users.AvatarImage = imageName;
                    userManager.UserAvatarImages(imageName);
                }
            }

            var result = usersService.UpdateAsync(id, users).Result;
            if (result.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                TempData["Message"] = result.Message;
                return View(usersService.GetUser(id).Result);
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(usersService.GetUser(id).Result);

            }
        }

        [HttpGet]
        [Route("/Panel/Users/UserList")]
        public IActionResult UserList()
        {
            ViewBag.Title = "Kullanıcı Listesi";
            return View(usersService.GetUsersList().Result);
        }

        [HttpGet]
        [Route("/panel/users/passwordchanged/{Id:Guid}")]
        public IActionResult PasswordChanged(Guid Id)
        {
            return View(usersService.GetUserPassword(Id).Result);
        }

        [HttpPost]
        [Route("/panel/users/passwordchanged/{Id:Guid}")]
        public IActionResult PasswordChanged(Guid Id, PasswordUpdateDTO passwordUpdateDTO)
        {
            var result = usersService.UpdateUserPassword(passwordUpdateDTO).Result;
            if (result.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                TempData["Message"] = result.Message;
                return Redirect($"/Panel/Users/Index/{Id}");
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(usersService.GetUserPassword(Id).Result);
            }
        }       
    }
}

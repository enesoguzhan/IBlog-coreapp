using IBlog.Business.EmailService;
using IBlog.Business.UserManager;
using IBlog.Entities.DTO.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class HomeController : Controller
    {
        readonly IEmailService emailService;

        public HomeController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            EmailDTO email = new()
            {
                To = "fohev68470@vpsrec.com",
                Body = "<h3>Sea HosGeldin</h3>",
                Subject = "IBlog Hoşgeldin"
            };

          // emailService.SendEmail(email);
            ViewBag.Title = "Kategori";
           

            return View();
        }
    }
}

using IBlog.Business.Abstract;
using IBlog.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class SocialLinksController : Controller
    {
        private readonly ISocialLinksService _socialLinksService;

        public SocialLinksController(ISocialLinksService socialLinksService)
        {
            _socialLinksService = socialLinksService;
        }

        [HttpGet]
        [Route("/panel/sociallinks/update/{Id:Guid}")]
        public IActionResult Update(Guid Id)
        {
            var data = _socialLinksService.GetSocialLinksByUserId(Id).Result;
            return View(data);
        }

        [HttpPost]
        [Route("/panel/sociallinks/update/{Id:Guid}")]
        public IActionResult Update(Guid Id, SocialLinks socialLinks)
        {
            return View();
        }

        [HttpGet]
        [Route("/panel/sociallinks/Insert")]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [Route("/panel/sociallinks/Insert")]
        public IActionResult Insert(SocialLinks socialLinks)
        {
            var result = _socialLinksService.AddAsync(socialLinks).Result;
            return View();
        }
    }
}

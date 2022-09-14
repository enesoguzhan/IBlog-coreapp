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
            ViewBag.Title = "Sosyal Link Ekle";
            var data = _socialLinksService.GetSocialLinksByUserId(Id).Result;
            return View(data);
        }

        [HttpPost]
        [Route("/panel/sociallinks/update/{Id:Guid}/{UserId:Guid}")]
        public IActionResult Update(Guid Id, SocialLinks socialLinks)
        {
            ViewBag.Title = "Sosyal Link Ekle";
            var result = _socialLinksService.UpdateAsync(socialLinks).Result;
            if (result.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                TempData["Message"] = result.Message;
            }
            else
            {
                ViewBag.Message = result.Message;
            }
            return View(_socialLinksService.GetSocialLinksByUserId(socialLinks.UserId).Result);
        }

        [HttpGet]
        [Route("/panel/sociallinks/Insert/{UserId}")]
        public IActionResult Insert(Guid UserId)
        {
            ViewBag.Title = "Sosyal Link Ekle";
            ViewBag.UserId = UserId;
            return View();
        }

        [HttpPost]
        [Route("/panel/sociallinks/Insert/{UserId}")]
        public IActionResult Insert(SocialLinks socialLinks)
        {
            ViewBag.Title = "Sosyal Link Ekle";
            var result = _socialLinksService.AddAsync(socialLinks).Result;
            if (result.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                TempData["Message"] = result.Message;
                return Redirect($"/panel/users/Index/{socialLinks.UserId}");
            }
            else
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }
    }
}

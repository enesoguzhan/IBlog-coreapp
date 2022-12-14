using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Kategori Listesi";
            var data = categoriesService.GetAllCategoriesAsync().Result;
            return View(data);
        }

        [HttpGet]
        [Route("/panel/categories/delete/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
           TempData["Message"] = categoriesService.DeleteAsync(id).Result.Message;
            return Redirect("/panel/categories");
        }
      
    }
}

using IBlog.Business.Abstract;
using IBlog.Entities;
using IBlog.Entities.DTO.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Yönetici,Yazar")]
    public class CategoriesJsonController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesJsonController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public JsonResult CategoriesInsert(CategoriesInsertDTO categories)
        {     
            var query = categoriesService.AddAsync(categories).Result;
            if (query.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                TempData["Message"] = query.Message.ToString();
                return Json(query);
            }
            else
                return Json(query);
        }
        public JsonResult CategoriesUpdate(CategoriesUpdateDTO categories)
        {
            var query = categoriesService.UpdateAsync(categories).Result;
            if (query.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                TempData["Message"] = query.Message.ToString();
                return Json(query);
            }
            else
                return Json(query);

        }
    }
}

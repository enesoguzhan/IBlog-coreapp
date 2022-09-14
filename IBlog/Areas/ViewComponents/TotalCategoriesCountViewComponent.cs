using IBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.Areas.ViewComponents
{
    public class TotalCategoriesCountViewComponent : ViewComponent
    {
        private readonly ICategoriesService _categoriesService;

        public TotalCategoriesCountViewComponent(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoriesService.TotalCategoriesCount().Result);
        }
    }
}

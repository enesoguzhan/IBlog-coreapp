using IBlog.Business.Abstract;
using IBlog.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace IBlog.UI.ViewComponents
{
    public class GetCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public GetCategoriesViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IViewComponentResult Invoke()
        {
            var data = categoriesService.GetCategoriesCount().Result;
            return View(data);
        }
    }
}

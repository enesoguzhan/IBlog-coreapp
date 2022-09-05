using IBlog.Core.Results;
using IBlog.Entities;
using IBlog.Entities.DTO.Categories;

namespace IBlog.Business.Abstract
{
    public interface ICategoriesService
    {
        public Task<IResult> AddAsync(Categories data);
        public Task<IResult> UpdateAsync(Categories data);
        public Task<IResult> DeleteAsync(Guid id);
        public Task<IList<Categories>> GetAllCategoriesAsync();     
        public Task<Categories> GetCategory(Guid id);
        public Task<IList<CategoriesListCountDTO>> GetCategoriesCount();
     
    }
}

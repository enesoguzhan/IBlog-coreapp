using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Categories;
using IBlog.Entities.DTO.PanelComponent;
using System.Runtime.CompilerServices;

namespace IBlog.Business.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(CategoriesInsertDTO data)
        {
            IList<Categories> getAllCategories = await unitOfWork.categoriesRepo.AsyncGetAll();
            foreach (var category in getAllCategories)
            {
                if (category.Name.ToLower() == data.Name.ToLower())
                {
                    return Result.FactoryResult(Core.Results.ComplexTypes.StatusCode.Error, "Aynı İsimde Kategori Olamaz");
                }
            }
            Categories categories = mapper.Map<Categories>(data);
            return await unitOfWork.categoriesRepo.AsyncAdd(categories).ContinueWith(s => unitOfWork.SaveChanges().Result);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            return await unitOfWork.categoriesRepo.AsyncDelete(s => s.Id == id).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Categories>> GetAllCategoriesAsync()
        {
            return await unitOfWork.categoriesRepo.AsyncGetAll();
        }

        public async Task<IList<CategoriesListCountDTO>> GetCategoriesCount()
        {
            IList<Categories> data = await unitOfWork.categoriesRepo.AsyncGetAll(s => s.Blogs.Count > 0, s => s.Blogs.Where(s => s.Status == true));

            return await Task.Run(() => mapper.Map<IList<CategoriesListCountDTO>>(data));
        }

        public async Task<Categories> GetCategory(Guid id)
        {
            return await unitOfWork.categoriesRepo.AsyncFirst(s => s.Id == id);
        }

        public async Task<TotalCategoriesCountDTO> TotalCategoriesCount()
        {
            int count = unitOfWork.categoriesRepo.AsyncGetAll().Result.Count;
            TotalCategoriesCountDTO totalCategoriesCount = new()
            {
                CategoriesCount = count
            };

            return await Task.Run(() => totalCategoriesCount);
        }

        public async Task<IResult> UpdateAsync(CategoriesUpdateDTO data)
        {
            Categories categories = mapper.Map<Categories>(data);
            return await unitOfWork.categoriesRepo.AsyncUpdate(categories).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }
    }
}

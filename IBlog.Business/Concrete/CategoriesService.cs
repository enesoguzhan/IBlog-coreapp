using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Categories;
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

        public async Task<IResult> AddAsync(Categories data)
        {
            return await unitOfWork.categoriesRepo.AsyncAdd(data).ContinueWith(s => unitOfWork.SaveChanges()).Result;
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
            var data = unitOfWork.categoriesRepo.AsyncGetAll(s=>s.Blogs.Count > 0,s=>s.Blogs).Result;
            
            return await Task.Run(() => mapper.Map<IList<CategoriesListCountDTO>>(data));
        }

        public async Task<Categories> GetCategory(Guid id)
        {            
            return await unitOfWork.categoriesRepo.AsyncFirst(s => s.Id == id);
        }

        public async Task<IResult> UpdateAsync(Categories data)
        {
            return await unitOfWork.categoriesRepo.AsyncUpdate(data).ContinueWith(s => unitOfWork.SaveChanges()).Result;

        }
    }
}

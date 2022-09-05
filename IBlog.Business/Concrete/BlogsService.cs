using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.UserManeger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Business.Concrete
{
    public class BlogsService : IBlogsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserManager userManager;

        public BlogsService(IUnitOfWork unitOfWork, IMapper mapper, IUserManager userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IResult> AddAsync(Blogs data)
        {
            UserClaims userClaims = userManager.GetUserClaims();

            data.UserId = new Guid(userClaims.Id);
            data.Id = Guid.NewGuid();
            data.PublishDateTime = DateTime.Now;
            return await unitOfWork.blogsRepo.AsyncAdd(data).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            return await unitOfWork.blogsRepo.AsyncDelete(s => s.Id == id).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Blogs>> GetAllBlogsAsync()
        {
            return await unitOfWork.blogsRepo.AsyncGetAll(null, s => s.Categories, x => x.User, d => d.Images);
        }

        public async Task<IList<Blogs>> GetAllBlogsGetByCategoriesAsync(Guid categoriesId)
        {
            return await unitOfWork.blogsRepo.AsyncGetAll(s => s.CategoryId == categoriesId);
        }

        public async Task<Blogs> GetBlog(Guid id)
        {
            return await unitOfWork.blogsRepo.AsyncFirst(s => s.Id == id);
        }

        public async Task<Blogs> GetBlogAllInclude(Guid id)
        {
            return await unitOfWork.blogsRepo.AsyncFirst(s => s.Id == id, a => a.Images, b => b.User, d => d.Categories);
        }

        public async Task<IList<LastAddedBlogsDTO>> GetLastAddedBlogs()
        {
            IList<Blogs> data = unitOfWork.blogsRepo.AsyncGetAll().Result.OrderByDescending(s => s.PublishDateTime).Take(3).ToList();
            return await Task.Run(() => mapper.Map<IList<LastAddedBlogsDTO>>(data));
        }

        public async Task<IResult> UpdateAsync(BlogsUpdateDTO data)
        {
            var das = mapper.Map<Blogs>(data);
            return await unitOfWork.blogsRepo.AsyncUpdate(mapper.Map<Blogs>(data)).ContinueWith(s => unitOfWork.SaveChanges()).Result;

        }
    }
}

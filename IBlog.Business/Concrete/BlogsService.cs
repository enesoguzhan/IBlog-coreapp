using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.UserManeger;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IList<Blogs>> GetAllBlogsActiveAsync()
        {
            return await unitOfWork.blogsRepo.AsyncGetAll(s => s.Status == true, s => s.Categories, x => x.User, d => d.Images);
        }

        public async Task<IList<Blogs>> GetAllBlogsGetByCategoriesAsync(Guid categoriesId)
        {
            return await unitOfWork.blogsRepo.AsyncGetAll(s => s.CategoryId == categoriesId && s.Status == true, s => s.Images, s => s.Categories, s => s.User);
        }

        public async Task<Blogs> GetBlog(Guid id)
        {
            return await unitOfWork.blogsRepo.AsyncFirst(s => s.Id == id);
        }

        public async Task<Blogs> GetBlogAllInclude(Guid id)
        {
            return await unitOfWork.blogsRepo.IncludeMultiple(s => s.Id == id, s => s.Include(s => s.Images)
            .Include(s => s.User)
            .Include(s => s.Categories)
            .Include(s => s.Comments).ThenInclude(s => s.User));

        }

        public async Task<IList<LastAddedBlogsDTO>> GetLastAddedBlogs()
        {
            IList<Blogs> data = unitOfWork.blogsRepo.AsyncGetAll(s => s.Status == true, s => s.Images).Result.OrderByDescending(s => s.PublishDateTime).Take(3).ToList();
            return await Task.Run(() => mapper.Map<IList<LastAddedBlogsDTO>>(data));
        }

        public async Task<IResult> UpdateAsync(BlogsUpdateDTO data)
        {
            var updateQuery = unitOfWork.blogsRepo.AsyncFirst(s => s.Id == data.Id, s => s.Images, s => s.User).Result;
            if (updateQuery != null)
            {
                updateQuery.Name = data.Name;
                updateQuery.Explanation = data.Explanation;
                updateQuery.CategoryId = data.CategoryId;
                updateQuery.Status = data.Status;
            }
            return await unitOfWork.blogsRepo.AsyncUpdate(updateQuery).ContinueWith(s => unitOfWork.SaveChanges()).Result;

        }

        public async Task<IList<BlogsListDTO>> GetListBlog()
        {
            var data = unitOfWork.blogsRepo.AsyncGetAll(null, s => s.Categories, s => s.User).Result;
            return await Task.Run(() => mapper.Map<IList<BlogsListDTO>>(data));
        }

        public async Task<IList<BlogsListDTO>> GetListBlogByUser(Guid id)
        {
            var data = unitOfWork.blogsRepo.AsyncGetAll(s => s.UserId == id, s => s.Categories).Result;
            return await Task.Run(() => mapper.Map<IList<BlogsListDTO>>(data));
        }
    }
}

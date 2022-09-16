using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.PanelComponent;
using IBlog.Entities.DTO.UserManeger;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IResult> AddAsync(BlogsInsertDTO data)
        {
            UserClaims userClaims = userManager.GetUserClaims();
            data.Id = Guid.NewGuid();
            var datas = mapper.Map<Blogs>(data);
            datas.UserId = new Guid(userClaims.Id);
            datas.PublishDateTime = DateTime.Now;
            return await unitOfWork.blogsRepo.AsyncAdd(datas).ContinueWith(s => unitOfWork.SaveChanges()).Result;
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
            Blogs updateQuery = await unitOfWork.blogsRepo.AsyncFirst(s => s.Id == data.Id, s => s.Images, s => s.User);
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
            IList<Blogs> data = await unitOfWork.blogsRepo.AsyncGetAll(null, s => s.Categories, s => s.User,s=>s.Comments);
            return await Task.Run(() => mapper.Map<IList<BlogsListDTO>>(data));
        }

        public async Task<IList<BlogsListDTO>> GetListBlogByUser(Guid id)
        {
            IList<Blogs> data = await unitOfWork.blogsRepo.AsyncGetAll(s => s.UserId == id, s => s.Categories);
            return await Task.Run(() => mapper.Map<IList<BlogsListDTO>>(data));
        }

        public async Task<BlogsUpdateDTO> GetUpdateBlogs(Guid Id)
        {
            Blogs data = await unitOfWork.blogsRepo.AsyncFirst(s => s.Id == Id, s => s.Images);

            return await Task.Run(() => mapper.Map<BlogsUpdateDTO>(data));
        }

        public async Task<TotalBlogsCountDTO> TotalBlogsCount()
        {
            int count = unitOfWork.blogsRepo.AsyncGetAll().Result.Count;
            TotalBlogsCountDTO totalBlogsCount = new()
            {
                BlogsCount = count
            };
            return await Task.Run(() => totalBlogsCount);
        }

        public Task<LastAddedBlogDTO> LastAddedBlog()
        {
            Blogs blog = unitOfWork.blogsRepo.AsyncGetAll(null, s => s.Images).Result.OrderByDescending(s => s.PublishDateTime).FirstOrDefault();
            return Task.Run(() => mapper.Map<LastAddedBlogDTO>(blog));
        }
    }
}

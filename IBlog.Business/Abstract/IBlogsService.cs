using IBlog.Core.Results;
using IBlog.Entities;
using IBlog.Entities.DTO.Blogs;
using IBlog.Entities.DTO.PanelComponent;

namespace IBlog.Business.Abstract
{
    public interface IBlogsService
    {
        public Task<IResult> AddAsync(BlogsInsertDTO data);
        public Task<IResult> UpdateAsync(BlogsUpdateDTO data);
        public Task<BlogsUpdateDTO> GetUpdateBlogs(Guid id);
        public Task<IResult> DeleteAsync(Guid id);
        public Task<IList<Blogs>> GetAllBlogsAsync();
        public Task<IList<Blogs>> GetAllBlogsActiveAsync();
        public Task<IList<Blogs>> GetAllBlogsGetByCategoriesAsync(Guid categoriesId);
        public Task<Blogs> GetBlog(Guid id);
        public Task<Blogs> GetBlogAllInclude(Guid id);
        public Task<IList<LastAddedBlogsDTO>> GetLastAddedBlogs();
        public Task<IList<BlogsListDTO>> GetListBlog();
        public Task<IList<BlogsListDTO>> GetListBlogByUser(Guid uid);
        public Task<TotalBlogsCountDTO> TotalBlogsCount();
        public Task<LastAddedBlogDTO> LastAddedBlog();
    }
}

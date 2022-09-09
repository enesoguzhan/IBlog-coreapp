using IBlog.Core.Results;
using IBlog.Entities;

namespace IBlog.Business.Abstract
{
    public interface IImagesService
    {
        public Task<IResult> AddAsync(string name,Guid blogId);
        public Task<IResult> DeleteAsync(Guid id);
        public Task<IList<Images>> GetImagesByBlogIdAsync(Guid BlogId);
    }
}

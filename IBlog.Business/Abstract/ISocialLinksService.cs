using IBlog.Entities;
using IBlog.Core.Results;

namespace IBlog.Business.Abstract
{
    public interface ISocialLinksService
    {
        public Task<IResult> AddAsync(Categories data);
        public Task<IResult> UpdateAsync(Categories data);
        public Task<IResult> DeleteAsync(Guid id);
        public Task<Categories> GetSocialLinksByUserId(Guid userId);

    }
}

using IBlog.Entities;
using IBlog.Core.Results;

namespace IBlog.Business.Abstract
{
    public interface ISocialLinksService
    {
        public Task<IResult> AddAsync(SocialLinks data);
        public Task<IResult> UpdateAsync(SocialLinks data);
        public Task<IResult> DeleteAsync(Guid id);
        public Task<SocialLinks> GetSocialLinksByUserId(Guid userId);

    }
}

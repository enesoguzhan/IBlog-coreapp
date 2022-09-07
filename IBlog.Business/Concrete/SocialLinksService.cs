using IBlog.Business.Abstract;
using IBlog.Core.Results;
using IBlog.Entities;

namespace IBlog.Business.Concrete
{
    public class SocialLinksService : ISocialLinksService
    {
        public Task<IResult> AddAsync(Categories data)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }      

        public Task<Categories> GetSocialLinksByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(Categories data)
        {
            throw new NotImplementedException();
        }
    }
}

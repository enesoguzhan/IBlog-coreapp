using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;

namespace IBlog.Business.Concrete
{
    public class SocialLinksService : ISocialLinksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _userManager;

        public SocialLinksService(IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IResult> AddAsync(SocialLinks data)
        {
            data.Id = Guid.NewGuid();
            data.UserId = new Guid(_userManager.GetUserClaims().Id);
            return await _unitOfWork.socialLinksRepo.AsyncAdd(data).ContinueWith(s => _unitOfWork.SaveChanges()).Result;
        }

        public Task<IResult> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<SocialLinks> GetSocialLinksByUserId(Guid userId)
        {
            return await _unitOfWork.socialLinksRepo.AsyncFirst(s => s.UserId == userId, s => s.User);
        }

        public Task<IResult> UpdateAsync(SocialLinks data)
        {
            throw new NotImplementedException();
        }
    }
}

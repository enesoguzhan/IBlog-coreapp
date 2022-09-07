using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Comments;

namespace IBlog.Business.Concrete
{
    public class CommentsService : ICommentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;

        public CommentsService(IUnitOfWork unitOfWork, IMapper mapper, IUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IResult> AddAsync(CommentsInsertDTO data)
        {
            var datass = _mapper.Map<Comments>(data);
            if (datass != null)
            {
                datass.Id = Guid.NewGuid();
                datass.CreationDate = DateTime.Now;
                datass.UserId = new Guid(_userManager.GetUserClaims().Id);
            }
            return await _unitOfWork.commentsRepo.AsyncAdd(datass).ContinueWith(s => _unitOfWork.SaveChanges()).Result;
        }
    }
}

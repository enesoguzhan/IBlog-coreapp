using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Business.UserManager;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Comments;
using IBlog.Entities.DTO.PanelComponent;

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
            Comments mapperData = _mapper.Map<Comments>(data);
            if (mapperData != null)
            {
                mapperData.Id = Guid.NewGuid();
                mapperData.CreationDate = DateTime.Now;
                mapperData.UserId = new Guid(_userManager.GetUserClaims().Id);
            }
            return await _unitOfWork.commentsRepo.AsyncAdd(mapperData).ContinueWith(s => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<CommentsListGetByBlogDTO>> GetCommentsByBlog(Guid BlogID)
        {
            IList<Comments> data = await _unitOfWork.commentsRepo.AsyncGetAll(s => s.BlogId == BlogID, s => s.Blog, s => s.User);

            return await Task.Run(() => _mapper.Map<IList<CommentsListGetByBlogDTO>>(data));
        }

        public async Task<TotalCommentsCountDTO> TotalCommentsCount()
        {
            int count = _unitOfWork.commentsRepo.AsyncGetAll().Result.Count;

            TotalCommentsCountDTO totalBlogsCount = new()
            {
                CommentsCount = count
            };

            return await Task.Run(() => totalBlogsCount);
        }
    }
}

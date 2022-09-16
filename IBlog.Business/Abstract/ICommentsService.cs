using IBlog.Core.Results;
using IBlog.Entities;
using IBlog.Entities.DTO.Comments;
using IBlog.Entities.DTO.PanelComponent;

namespace IBlog.Business.Abstract
{
    public interface ICommentsService
    {
        public Task<IResult> AddAsync(CommentsInsertDTO data);
        public Task<TotalCommentsCountDTO> TotalCommentsCount();
        public Task<IList<CommentsListGetByBlogDTO>> GetCommentsByBlog(Guid BlogID);
    }
}

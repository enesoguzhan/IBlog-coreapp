using IBlog.Core.Results;
using IBlog.Entities;
using IBlog.Entities.DTO.Comments;

namespace IBlog.Business.Abstract
{
    public interface ICommentsService 
    {
        public Task<IResult> AddAsync(CommentsInsertDTO data);

    }
}

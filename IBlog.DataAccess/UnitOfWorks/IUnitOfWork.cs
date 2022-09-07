using IBlog.Core.Results;
using IBlog.DataAccess.Abstract;

namespace IBlog.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IBlogsRepo blogsRepo { get; }
        public ICategoriesRepo categoriesRepo { get; }
        public ICommentsRepo commentsRepo { get; }
        public IInteractionsRepo interactionsRepo { get; }
        public IUsersRepo usersRepo { get; }
        public IImagesRepo imagesRepo { get; }
        public ISocialLinksRepo socialLinksRepo { get; }
        public Task<IResult> SaveChanges();
    }
}

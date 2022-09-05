using IBlog.Core.Results;
using IBlog.Core.Results.ComplexTypes;
using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBlogContext context;

        public UnitOfWork(IBlogContext context)
        {
            this.context = context;
        }

        private BlogsRepo blogs;
        private CategoriesRepo categories;
        private CommentsRepo comments;
        private InteractionsRepo interactions;
        private UsersRepo users;
        private ImagesRepo images;

        public IBlogsRepo blogsRepo => blogs ?? new BlogsRepo(context);

        public ICategoriesRepo categoriesRepo => categories ?? new CategoriesRepo(context);

        public ICommentsRepo commentsRepo => comments ?? new CommentsRepo(context);

        public IInteractionsRepo interactionsRepo => interactions ?? new InteractionsRepo(context);

        public IUsersRepo usersRepo => users ?? new UsersRepo(context);

        public IImagesRepo imagesRepo => images ?? new ImagesRepo(context);

        public async Task<IResult> SaveChanges()
        {
            using (context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    context.Database.CommitTransaction();
                    return Result.FactoryResult(StatusCode.Success, "İşlem Başarılı");
                }
                catch (Exception ex)
                {
                    context.Database.RollbackTransaction();
                    return Result.FactoryResult(StatusCode.Error, "İşlem Başarısız");
                }
            }
        }
    }
}

using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Repository;

namespace IBlog.DataAccess.Concrete
{
    public class BlogsRepo : Repositories<Blogs>, IBlogsRepo
    {
        public BlogsRepo(DbContext context) : base(context)
        {
        }
    }
}

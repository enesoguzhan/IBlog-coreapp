using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Repository;

namespace IBlog.DataAccess.Concrete
{
    public class CategoriesRepo : Repositories<Categories>, ICategoriesRepo
    {
        public CategoriesRepo(DbContext context) : base(context)
        {
        }
    }
}

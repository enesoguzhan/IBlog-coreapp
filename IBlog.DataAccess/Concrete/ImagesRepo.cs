using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Repository;

namespace IBlog.DataAccess.Concrete
{
    public class ImagesRepo : Repositories<Images>, IImagesRepo
    {
        public ImagesRepo(DbContext context) : base(context)
        {
        }
    }
}

using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Repository;

namespace IBlog.DataAccess.Concrete
{
    public class SocialLinksRepo : Repositories<SocialLinks>, ISocialLinksRepo
    {
        public SocialLinksRepo(DbContext context) : base(context)
        {
        }
    }
}

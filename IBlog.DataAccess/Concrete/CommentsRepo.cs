using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Concrete
{
    public class CommentsRepo : Repositories<Comments>, ICommentsRepo
    {
        public CommentsRepo(DbContext context) : base(context)
        {
        }
    }
}

using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Concrete
{
    public class InteractionsRepo : Repositories<Interactions>, IInteractionsRepo
    {
        public InteractionsRepo(DbContext context) : base(context)
        {
        }
    }
}

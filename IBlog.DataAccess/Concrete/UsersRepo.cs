using IBlog.DataAccess.Abstract;
using IBlog.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.DataAccess.Concrete
{
    public class UsersRepo : Repositories<Users>, IUsersRepo
    {
        private readonly DbContext context;
        public UsersRepo(DbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<string> ForgotPassword(string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> Login(string email, string password)
        {            
            return await context.Set<Users>().Where(s => s.Email == email && s.Password == password).FirstOrDefaultAsync();
        }
    }
}

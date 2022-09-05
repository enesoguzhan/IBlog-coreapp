using IBlog.DataAccess.Repository;

namespace IBlog.DataAccess.Abstract
{
    public interface IUsersRepo : IRepositories<Users>
    {
        public Task<Users> Login(string email, string password);
        public Task<string> ForgotPassword(string password);
    }
}

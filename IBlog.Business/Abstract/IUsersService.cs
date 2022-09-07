using IBlog.Core.Results;
using IBlog.Entities;
using IBlog.Entities.DTO.Users;

namespace IBlog.Business.Abstract
{
    public interface IUsersService
    {
        public Task<IResult> AddAsync(Users data);
        public Task<IResult> UpdateAsync(Guid id, Users data);
        public Task<IResult> DeleteAsync(Guid id);
        public Task<IList<Users>> GetAllUsers();
        public Task<IList<UserListDTO>> GetUsersList();
        public Task<Users> GetUser(Guid id);
        public Task<Users> LoginAsync(string Email, string Password);
        public Task<string> PaswordForgotAsync(string Email);
        public Task<AuthorsBlogsDTO> GetAuthorsBlogs(Guid userId);
        public Task<PasswordUpdateDTO> GetUserPassword(Guid userId);
        public Task<IResult> UpdateUserPassword(PasswordUpdateDTO passwordUpdateDTO);
        public Task<IList<AuthorsCartDTO>> GetAuthorsCart();

    }
}

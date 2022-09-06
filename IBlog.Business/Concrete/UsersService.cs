using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.Users;
using Microsoft.EntityFrameworkCore;

namespace IBlog.Business.Concrete
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(Users data)
        {
            data.Id = Guid.NewGuid();
            data.RoleType = 0;
            return await unitOfWork.usersRepo.AsyncAdd(data).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            return await unitOfWork.usersRepo.AsyncDelete(s => s.Id == id).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Users>> GetAllUsers()
        {
            return await unitOfWork.usersRepo.AsyncGetAll();
        }

        public async Task<AuthorsBlogsDTO> GetAuthorsBlogs(Guid userId)
        {
           // Users data = unitOfWork.usersRepo.AsyncFirst(s => s.Id == userId, s => s.Blogs).Result;
            Users data = unitOfWork.usersRepo.IncludeMultiple(s => s.Id == userId, s => s.Include(s => s.Blogs)
            .ThenInclude(s => s.Images).
            Include(s => s.Blogs).
            ThenInclude(s => s.Categories)).Result;
            return await Task.Run(() => mapper.Map<AuthorsBlogsDTO>(data));
        }

        public async Task<Users> GetUser(Guid id)
        {
            return await unitOfWork.usersRepo.AsyncFirst(s => s.Id == id);
        }

        public async Task<IList<UserListDTO>> GetUsersList()
        {
            var data = unitOfWork.usersRepo.AsyncGetAll(null, s => s.Blogs).Result;
            return await Task.Run(() => mapper.Map<IList<UserListDTO>>(data));
        }

        public async Task<Users> LoginAsync(string Email, string Password)
        {
            return await unitOfWork.usersRepo.Login(Email, Password);
        }

        public async Task<string> PaswordForgotAsync(string Email)
        {
            return await unitOfWork.usersRepo.ForgotPassword(Email);
        }

        public async Task<IResult> UpdateAsync(Guid id, Users data)
        {
            var user = unitOfWork.usersRepo.AsyncFirst(s => s.Id == id).Result;
            if (user != null)
            {
                user.Name = data.Name;
                user.Surname = data.Surname;
                user.Email = data.Email;
                user.Explanation = data.Explanation;
                user.Password = data.Password;
                user.AvatarImage = data.AvatarImage ?? user.AvatarImage;
            }
            return await unitOfWork.usersRepo.AsyncUpdate(user).ContinueWith(s => unitOfWork.SaveChanges()).Result;

        }
    }
}

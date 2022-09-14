using AutoMapper;
using IBlog.Business.Abstract;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using IBlog.Entities.DTO.PanelComponent;
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
            data.CreationDatetime = DateTime.Now;
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
            ThenInclude(s => s.Categories)
            .Include(s => s.SocialLinks)).Result;
            return await Task.Run(() => mapper.Map<AuthorsBlogsDTO>(data));
        }

        public Task<IList<AuthorsCartDTO>> GetAuthorsCart()
        {
            var data = unitOfWork.usersRepo.AsyncGetAll().Result;
            return Task.Run(() => mapper.Map<IList<AuthorsCartDTO>>(data));
        }

        public async Task<Users> GetUser(Guid id)
        {
            return await unitOfWork.usersRepo.AsyncFirst(s => s.Id == id, s => s.SocialLinks);
        }

        public Task<PasswordUpdateDTO> GetUserPassword(Guid userId)
        {
            Users data = unitOfWork.usersRepo.AsyncFirst(s => s.Id == userId).Result;
            return Task.Run(() => mapper.Map<PasswordUpdateDTO>(data));
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

        public Task<NewUsersDTO> NewUsers()
        {
            Users user = unitOfWork.usersRepo.AsyncGetAll().Result.OrderByDescending(s => s.CreationDatetime).FirstOrDefault();
            return Task.Run(() => mapper.Map<NewUsersDTO>(user));
        }

        public async Task<string> PaswordForgotAsync(string Email)
        {
            return await unitOfWork.usersRepo.ForgotPassword(Email);
        }

        public async Task<TotalUsersCountDTO> TotalUsersCount()
        {
            int count = unitOfWork.usersRepo.AsyncGetAll().Result.Count;
            TotalUsersCountDTO totalUsersCount = new()
            {
                UsersCount = count
            };
            return await Task.Run(() => totalUsersCount);
        }

        public async Task<IResult> UpdateAsync(Guid id, Users data)
        {
            var user = unitOfWork.usersRepo.AsyncFirst(s => s.Id == id).Result;
            if (user != null)
            {
                user.Name = data.Name;
                user.Surname = data.Surname;
                user.Explanation = data.Explanation;
                user.AvatarImage = data.AvatarImage ?? user.AvatarImage;
            }
            return await unitOfWork.usersRepo.AsyncUpdate(user).ContinueWith(s => unitOfWork.SaveChanges()).Result;

        }

        public async Task<IResult> UpdateUserPassword(PasswordUpdateDTO passwordUpdateDTO)
        {
            Users users = unitOfWork.usersRepo.AsyncFirst(s => s.Id == passwordUpdateDTO.Id).Result;
            if (users.Password != passwordUpdateDTO.OldPassword)
            {
                return Result.FactoryResult(Core.Results.ComplexTypes.StatusCode.Error, "Eski şifre uyuşmuyor");
            }
            if (users != null)
            {
                users.Password = passwordUpdateDTO.Password;
            }
            return await unitOfWork.usersRepo.AsyncUpdate(users).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }
    }
}

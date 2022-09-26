using IBlog.Entities.DTO.UserManeger;

namespace IBlog.Business.UserManager
{
    public interface IUserManager
    {
        public UserClaims GetUserClaims();
        public void UserAvatarImages(string name);     
    }
}

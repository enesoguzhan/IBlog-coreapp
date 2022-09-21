using IBlog.Entities.DTO.UserManeger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Business.UserManager
{
    public interface IUserManager
    {
        public UserClaims GetUserClaims();
        public void UserAvatarImages(string name);
        public void UserSingOut();
    }
}

using IBlog.Entities.DTO.UserManeger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IBlog.Business.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserManager(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public UserClaims GetUserClaims()
        {
            UserClaims userClaims = new();
            var data = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            foreach (var item in data.Claims)
            {
                if (item.Type == "Id")
                {
                    userClaims.Id = item.Value;
                }
                else if (item.Type == "AvatarImage")
                {
                    userClaims.AvatarImage = item.Value;
                }
                else if (item.Type == ClaimTypes.Role)
                {
                    userClaims.Role = item.Value;
                }
                else if (item.Type == ClaimTypes.Name)
                {
                    userClaims.NameSurname = item.Value;
                }
                else if (item.Type == "NameSurnameFirstChar")
                {
                    userClaims.NameSurnameFirstChar = item.Value;
                }
            }
            return userClaims;
        }

        public void UserAvatarImages(string imageName)
        {
            var identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            identity.RemoveClaim(identity.FindFirst("AvatarImage"));
            identity.AddClaim(new Claim("AvatarImage", imageName));

            var cookiesTime = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddDays(1),
                IsPersistent = true,
            };
            httpContextAccessor.HttpContext.SignInAsync(httpContextAccessor.HttpContext.User, cookiesTime);
        }

        public async void UserSingOut()
        {
            await httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}

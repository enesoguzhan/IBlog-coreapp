using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Entities.DTO.UserManeger
{
    public class UserClaims
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Role { get; set; }
        public string AvatarImage { get; set; }
        public string NameSurnameFirstChar { get; set; }
    }
}

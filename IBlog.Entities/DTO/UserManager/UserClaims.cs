namespace IBlog.Entities.DTO.UserManeger
{
    public class UserClaims :IDTO
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Role { get; set; }
        public string AvatarImage { get; set; }
        public string NameSurnameFirstChar { get; set; }
    }
}

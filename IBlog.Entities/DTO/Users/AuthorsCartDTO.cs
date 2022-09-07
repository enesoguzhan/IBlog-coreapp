namespace IBlog.Entities.DTO.Users
{
    public class AuthorsCartDTO : IDTO
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string AvatarImage { get; set; }
        public string RoleName { get; set; }
        public string Explanation { get; set; }

    }
}

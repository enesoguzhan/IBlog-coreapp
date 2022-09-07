namespace IBlog.Entities.DTO.Users
{
    public class PasswordUpdateDTO : IDTO
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }

    }
}

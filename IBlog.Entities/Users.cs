namespace IBlog.Entities
{
    public class Users : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Explanation { get; set; }
        public string? AvatarImage { get; set; } = "profilepic.png";
        public DateTime CreationDatetime { get; set; }
        public int RoleType { get; set; }
        public List<Blogs> Blogs { get; set; }  
        public SocialLinks SocialLinks { get; set; }
        public List<Comments> Comments { get; set; }
    }
}

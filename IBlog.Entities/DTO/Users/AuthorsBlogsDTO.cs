namespace IBlog.Entities.DTO.Users
{
    public class AuthorsBlogsDTO : IDTO
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }       
        public string Email { get; set; }
        public string Explanation { get; set; }
        public string AvatarImage { get; set; }
        public List<IBlog.Entities.Blogs> Blogs { get; set; }    
        public SocialLinks SocialLinks { get; set; }
    }
}

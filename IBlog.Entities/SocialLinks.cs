namespace IBlog.Entities
{
    public class SocialLinks : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Facebook { get; set; }
        public string? Github { get; set; }
        public string? Linkedin { get; set; }
        public string? Twitter { get; set; }
        public Users User { get; set; }
    }
}

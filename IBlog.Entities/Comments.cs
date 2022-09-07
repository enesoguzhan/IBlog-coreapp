namespace IBlog.Entities
{
    public class Comments : IEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
        public Guid BlogId { get; set; }
        public Blogs Blog { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; }
    }
}

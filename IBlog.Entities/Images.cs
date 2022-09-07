namespace IBlog.Entities
{
    public class Images : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BlogId { get; set; }
        public Blogs Blog { get; set; }
    }
}


namespace IBlog.Entities
{
    public class Interactions : IEntity
    {
        public Guid Id { get; set; }
        public bool InteracitonType { get; set; }
        public DateTime InteractionDate { get; set; }
        public string IpAddress { get; set; }
        public Guid BlogId { get; set; }
        public Blogs Blog { get; set; }
    }
}

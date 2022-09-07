namespace IBlog.Entities
{
    public class Blogs : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }     
        public bool Status { get; set; }
        public Users User { get; set; }
        public List<Interactions> Interactions { get; set; }
        public List<Comments> Comments { get; set; }
        public Categories Categories { get; set; }
        public List<Images> Images { get; set; }

    }
}

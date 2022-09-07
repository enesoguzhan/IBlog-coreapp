namespace IBlog.Entities
{
    public class Categories : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Blogs> Blogs { get; set; }
    }
}

namespace IBlog.Entities.DTO.Blogs
{
    public class BlogsListDTO : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDateTime { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
        public IList<IBlog.Entities.Comments> Comments { get; set; }
    }
}

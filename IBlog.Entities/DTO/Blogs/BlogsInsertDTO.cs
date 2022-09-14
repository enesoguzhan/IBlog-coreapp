namespace IBlog.Entities.DTO.Blogs
{
    public class BlogsInsertDTO : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }          
        public Guid CategoryId { get; set; }
        public bool Status { get; set; }
    }
}

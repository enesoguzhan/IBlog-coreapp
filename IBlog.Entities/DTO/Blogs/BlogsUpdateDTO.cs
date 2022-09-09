namespace IBlog.Entities.DTO.Blogs
{
    public class BlogsUpdateDTO : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public Guid CategoryId { get; set; }
        public bool Status { get; set; }
        public List<Images> Images { get; set; }
    }
}

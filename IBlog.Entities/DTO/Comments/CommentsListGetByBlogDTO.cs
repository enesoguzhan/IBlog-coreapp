namespace IBlog.Entities.DTO.Comments
{
    public class CommentsListGetByBlogDTO
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public string BlogName { get; set; }
        public string UserNameSurname { get; set; }
    }
}

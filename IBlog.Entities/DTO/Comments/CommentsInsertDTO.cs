namespace IBlog.Entities.DTO.Comments
{
    public class CommentsInsertDTO : IDTO
    {
        public string Comment { get; set; }     
        public Guid BlogId { get; set; }     
    }
}

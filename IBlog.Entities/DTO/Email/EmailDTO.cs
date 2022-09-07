namespace IBlog.Entities.DTO.Email
{
    public class EmailDTO :IDTO
    {
        public string To { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}

namespace IBlog.Entities.DTO.PanelComponent
{
    public class LastAddedBlogDTO : IDTO
    {       
        public string Name { get; set; }
        public string Explanation { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string Image { get; set; }
    }
}

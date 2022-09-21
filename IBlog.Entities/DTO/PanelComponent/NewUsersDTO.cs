namespace IBlog.Entities.DTO.PanelComponent
{
    public class NewUsersDTO : IDTO
    {
        public string NameSurname { get; set; }
        public string Explanation { get; set; }
        public string AvatarImage { get; set; } 
        public DateTime CreationDatetime { get; set; }
    }
}

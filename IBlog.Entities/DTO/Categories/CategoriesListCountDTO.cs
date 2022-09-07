namespace IBlog.Entities.DTO.Categories
{
    public class CategoriesListCountDTO : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}

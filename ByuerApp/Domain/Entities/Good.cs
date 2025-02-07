namespace ByuerApp.Domain.Entities
{
    public class Good
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public Guid BrandId { get; set; }
    }
}

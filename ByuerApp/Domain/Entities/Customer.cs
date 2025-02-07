namespace ByuerApp.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid CityId { get; set; }
        public string FullAddress { get; set; }
        public int PostalCode { get; set; }
    }
}

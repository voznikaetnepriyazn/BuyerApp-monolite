namespace ByuerApp.Domain.Entities
{
    public class Good
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public Guid BrandId { get; set; }
        public IEnumerable<Good> Goods { get; set; }
        public Types Types { get; set; }
        public Brand Brand { get; set; } 
        public IEnumerable<Order> Order = new List<Order>();
        public int Rest {  get; set; }
        public IEnumerable<GoodInOrder> GoodInOrder { get; set; } = new List<GoodInOrder>();
    }
}

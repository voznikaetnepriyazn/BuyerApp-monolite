namespace ByuerApp.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid IdOfClient { get; set; }
        public virtual IEnumerable<Good> GoodsinOrder { get; set; } = new List<Good>();
        public IEnumerable<Good> Good { get; set; } = new List<Good>();
        public Customer Customer { get; set; }
        public Types Types { get; set; }

    }
}

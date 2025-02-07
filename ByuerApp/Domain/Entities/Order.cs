namespace ByuerApp.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid IdOfClient { get; set; }
        public virtual ICollection<Good> GoodsinOrder { get; set; } = new List<Good>();
        
    }
}

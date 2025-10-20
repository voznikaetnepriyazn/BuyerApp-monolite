namespace ByuerApp.Domain.Entities
{
    public class GoodInOrder
    {
        public Guid Id { get; set; }
        public Guid IdOfClient { get; set; }
        public Order Order { get; set; }
        public Good Good { get; set; }
        public Guid IdOfGood { get; set; }
        public Guid IdOfOrder { get; set; }
    }
}

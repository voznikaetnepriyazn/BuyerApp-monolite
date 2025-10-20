using ByuerApp.Domain.Interfaces;
using ByuerApp.Domain.Entities;

namespace ByuerApp.Domain.Servises
{
    public class OrderServise : IOrderServise
    {
        private readonly IRepository<Order> orderRepository;
        public OrderServise(IRepository<Order> orderRepository) 
        {
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<bool> IsOrderCreated(Guid Id)
        {
            Order order = await orderRepository.GetByIdAsync(Id);
            if (order == null)
            {
                return false;
            }
            return true;
        }
    }
}

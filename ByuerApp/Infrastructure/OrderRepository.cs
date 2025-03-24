using ByuerApp.Domain.Entities;
using ByuerApp.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace ByuerApp.Infrastructure
{
    public class OrderRepository: RepositoryBase<Order>, IRepository<Order> 
    {
        public OrderRepository(IConfiguration configuration) : base(configuration) { }
        public async Task AddAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            await this.ToDb($"INSERT INTO dbo.Order (Id, IdOfClient, GoodsinOrder) VALUES ('{Guid.NewGuid}, {order.IdOfClient}, {order.GoodsinOrder}')");
        }

        public async Task DeleteAsync(Guid Id)
        {
            await this.ToDb($"DELETE FROM dbo.Order WHERE id='{Id}'");
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var res1 = await this.ReachToDb($"SELECT Order.Id, Good.Id FROM dbo.Order INNER JOIN dbo.GoodInOrder ON Order.IdOfClient = GoodInOrder.IdOfClient INNER JOIN Good ON GoodInOrder.Id = Good.Id");
            return res1;
            //foreach (var abc in res1)//вывести для каждого заказа запрос в базу
            //{
                //await this.ReachToDb($"SELECT * FROM dbo.GoodInOrder");
            //}//3 способ - inner join запрос
        }


        public async Task<Order> GetByIdAsync(Guid Id) 
        {
            var res = await this.ReachToDb($"SELECT * FROM dbo.Order WHERE id='{Id}'");
            return res?.SingleOrDefault();
        }

            public async Task UpdateAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            await this.ToDb($"UPDATE dbo.Order SET IdOfClient='{order.IdOfClient}' WHERE Id='{order.Id}'"); 
        }
        protected override Order GetEntityFromReader(SqlDataReader reader)
        {
            return new Order
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                IdOfClient = reader.GetGuid(reader.GetOrdinal("IdOfClient"))
            };
        }
    }
}

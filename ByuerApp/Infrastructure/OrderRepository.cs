using ByuerApp.Domain.Entities;
using ByuerApp.Domain.Interfaces;
using System.Data.SqlClient;

namespace ByuerApp.Infrastructure
{
    public class OrderRepository: RepositoryBase, IRepository<Order>//ошибка - не реализует последний метод, отсутствует аргумент для параметра configuration 
    {
        public async Task AddAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            await this.ToDb($"INSERT INTO dbo.Order (Id, IdOfClient, GoodsinOrder) VALUES ('{Guid.NewGuid}, {order.IdOfClient}, {order.GoodsinOrder}')");
        }

        public async Task DeleteAsync(Guid Id)
        {
            await this.ToDb($"DELETE FROM dbo.Order WHERE id='{Id}'");
        }

        public async Task<IEnumerable<Order>> GetAllAsync()//не все пути к коду возвращают значение
        {
            await this.ReachToDb($"SELECT * FROM dbo.Order");
        }

        public async Task<Order> GetByIdAsync(Guid Id)//не все пути к коду возвращают значение
        {
            await this.ReachToDb($"SELECT * FROM dbo.Order WHERE id='{Id}'");
        }
        public async Task UpdateAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            await this.ToDb($"UPDATE dbo.Order SET IdOfClient='{order.IdOfClient}' WHERE Id='{order.Id}'");
        }
        protected override Order GetEntityFromReader(SqlDataReader reader)//не понимает что такое SqlDataReader
        {
            return new Order
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                IdOfClient = reader.GetGuid(reader.GetOrdinal("IdOfClient")),
                GoodsinOrder = reader.GetGuid(reader.GetOrdinal("GoodsinOrder"))
            };
        }
    }
}

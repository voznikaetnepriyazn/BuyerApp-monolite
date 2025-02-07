using ByuerApp.Domain.Interfaces;
using ByuerApp.Domain.Entities;

namespace ByuerApp.Infrastructure
{
    public class CustomerRepository: RepositoryBase,IRepository<Customer>//ошибка - не реализует последний метод, отсутствует аргумент для параметра configuration
    {
        public async Task AddAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await this.ToDb($"INSERT INTO dbo.Customer (Id, FullName, Email, PasswordHash, CityId, FullAddress, PostalCode) VALUES ('{Guid.NewGuid}', '{customer.FullName}','{customer.Email}','{customer.PasswordHash}','{customer.CityId}','{customer.FullAddress}','{customer.PostalCode}')");
        }

        public async Task DeleteAsync(Guid Id)
        {
            await this.ToDb($"DELETE FROM dbo.Customer WHERE id='{Id}'");
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()//не все пути к коду возвращают значение
        {
            await this.ReachToDb($"SELECT * FROM dbo.Customer");
        }

        public async Task<Customer> GetByIdAsync(Guid Id)//не все пути к коду возвращают значение
        {
            await this.ReachToDb($"SELECT * FROM dbo.Customer WHERE id='{Id}'");
        }
        public async Task UpdateAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await this.ToDb($"UPDATE dbo.Customer SET FullName='{customer.FullName}", Email='{customer.Email}', PasswordHash='{customer.PasswordHash}', CityId='{customer.CityId}', FullAddress='{customer.FullAddress}',PostalCode='{customer.PostalCode}' WHERE Id='{customer.Id}'"); 
        }//в строчке выше синтаксические ошибки
        protected override Customer GetEntityFromReader(SqlDataReader reader)//не понимает что такое SqlDataReader
        {
            return new Customer
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                CityId = reader.GetGuid(reader.GetOrdinal("CityId")),
                FullAddress = reader.GetString(reader.GetOrdinal("FullAddress")),
                PostalCode = reader.GetInt64(reader.GetOrdinal("PostalCode"))
            };
        }
    }
}

using ByuerApp.Domain.Interfaces;
using ByuerApp.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace ByuerApp.Infrastructure
{
    public class CustomerRepository: RepositoryBase<Customer>,IRepository<Customer>
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration) { }
        public async Task AddAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await this.ToDb($"INSERT INTO dbo.Customer (Id, FullName, Email, PasswordHash, CityId, FullAddress, PostalCode) VALUES ('{Guid.NewGuid}', '{customer.FullName}','{customer.Email}','{customer.PasswordHash}','{customer.CityId}','{customer.FullAddress}','{customer.PostalCode}')");
        }

        public async Task DeleteAsync(Guid Id)
        {
            await this.ToDb($"DELETE FROM dbo.Customer WHERE id='{Id}'");
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
            => await this.ReachToDb($"SELECT * FROM dbo.Customer");

        public async Task<Customer> GetByIdAsync(Guid Id)
        {
            var res = await this.ReachToDb($"SELECT * FROM dbo.Customer WHERE id='{Id}'");
            return res?.SingleOrDefault();
        }
        public async Task UpdateAsync(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            await this.ToDb($"UPDATE dbo.Customer SET FullName='{customer.FullName}', Email = '{customer.Email}', PasswordHash='{customer.PasswordHash}', CityId='{customer.CityId}', FullAddress='{customer.FullAddress}',PostalCode='{customer.PostalCode}' WHERE Id='{customer.Id}'"); 
        }
        protected override Customer GetEntityFromReader(SqlDataReader reader)
        {
            return new Customer
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                CityId = reader.GetGuid(reader.GetOrdinal("CityId")),
                FullAddress = reader.GetString(reader.GetOrdinal("FullAddress")),
                PostalCode = reader.GetInt16(reader.GetOrdinal("PostalCode"))
            };
        }
    }
}

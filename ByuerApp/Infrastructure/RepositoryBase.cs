using ByuerApp.Domain.Entities;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace ByuerApp.Domain.Interfaces
{
    public abstract class RepositoryBase
    {
        protected readonly string connectionString;
        public RepositoryBase(IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            this.connectionString = configuration.GetConnectionString("Main") ?? throw new ArgumentNullException("Ошибка конфигурации. Не заполнен параметр ConnectionStrings: MainConnectionString");
        }
        //метод для get - почему для гетов один шаблонный метод, а для остальных методов - другой шаблон????
        protected async Task<IEnumerable<T>> ReachToDb(string sql)//ошибка - не удалось найти пространство имен для Т
        {
            if (string.IsNullOrWhiteSpace(sql)) throw new ArgumentNullException(nameof(sql));//на вход в метод - конкретный запрос

            var result = new List<T>();//ошибка - не удалось найти пространство имен для Т
            using (var connection = new SqlConnection(connectionString.GetConnectionString("MainConnectionString")))//указываем строку подключения в скобках, не понимает че такое SqlConnection(connectionString
            {
                using (var command = new SqlCommand(sql, connection))//аргументы - конкретный запрос и connection, не понимает че такое скл комманд
                {
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();//запуск команды
                    while (await reader.ReadAsync())
                    {
                        result.Add(this.GetEntityFromReader(reader));
                    }
                }
            }
            return result;
        }
        protected async Task ToDb(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) throw new ArgumentNullException(nameof(sql));//на вход в метод - конкретный запрос

            using (var connection = new SqlConnection(connectionString))//ошибка та же
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(sql, connection))//ошибка та же
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        protected abstract T GetEntityFromReader(SqlReader reader);//ошибка та же
    }
}

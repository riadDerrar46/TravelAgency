using Core.Application.DB;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DBHandler.Dapper
{
    public class Generic_CRUD : IGeneric_CRUD
    {
        private readonly IConfiguration _configuration;

        public Generic_CRUD(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //read table
        private async Task<IEnumerable<T>> LoadTable<T, U>(string storedProcedure, U parameters, string connectionName = "Default") where T : class
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionName));

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        //update, delete, insert table
        private async Task ExecuteCommand<U>(string storedProcedure, U parameters, string connectionName = "Default") where U : class
        {

            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionName));
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task CreateAsync<T>(T entity) where T : class
        {
            var entityName = typeof(T).Name;

            // Deconstruct the entity and remove the Id property
            var parameters = entity.GetType()
                .GetProperties()
                .Where(p => p.Name != "Id") // Exclude the Id property
                .ToDictionary(p => p.Name, p => p.GetValue(entity));

            await ExecuteCommand($"sp{entityName}_Create", parameters);
        }

        public async Task DeleteAsync<T>(int id) where T : class
        {
           var entityName = typeof(T).Name;
            await  ExecuteCommand($"sp{entityName}_Delete", new { Id = id });
        }


        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
           var entityName = typeof(T).Name;
            var result = await LoadTable<T, dynamic>($"sp{entityName}_GetByID", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
           var entityName = typeof(T).Name;
            await  ExecuteCommand<T>($"sp{entityName}_Edit", entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
           var entityName = typeof(T).Name;
            var result = await LoadTable<T, dynamic>($"sp{entityName}_GetAll", new { });
            return result.ToList();
        }




        
        public async Task<IEnumerable<T>> Search<T>(dynamic param) where T : class
        {
            var entityName = typeof(T).Name;
            return await LoadTable<T, dynamic>($"sp{entityName}_Search", param);
        }
    }
}

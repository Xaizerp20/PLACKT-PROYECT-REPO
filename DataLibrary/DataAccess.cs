using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T>(string sql, T parameters, string connectionString)
        {

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {

                int rowsAffected = await connection.ExecuteAsync(sql, parameters);

                return rowsAffected;


            }
        }
    }
}

using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    const string connectionString = "Host=localhost;database=Ecommerse_07_05_db;user id =postgres; password=sr000080864";
    public IDbConnection GetConnection(){
        return new NpgsqlConnection(connectionString);
    }
}

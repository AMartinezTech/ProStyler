using Microsoft.Data.SqlClient;

namespace AMartinezTech.Infrastucture.Utils.SqlServer.Persistence;

public abstract class AdoRepositoryBase(string connectionString)
{
    protected readonly string _connectionString = connectionString;

    protected SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

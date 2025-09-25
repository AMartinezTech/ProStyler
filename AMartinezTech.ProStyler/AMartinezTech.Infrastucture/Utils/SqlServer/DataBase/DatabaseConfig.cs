using System.Text.Json;

namespace AMartinezTech.Infrastucture.Utils.SqlServer.DataBase;

public class DatabaseConfig
{
    public string Server { get; private set; } = string.Empty;
    public string Database { get; private set; } = string.Empty;
    private string User { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;

    public string GetConnectionString()
    {
        var server = string.IsNullOrWhiteSpace(Server) ? "localhost" : Server;
        var database = string.IsNullOrWhiteSpace(Database) ? "prostyledb" : Database;

        if (!string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Password))
        {
            return $"Server={server};Database={database};User Id={User};Password={Password};";
        }

        return $"Server={server};Database={database};Trusted_Connection=True;";
    }

    public static DatabaseConfig Load(string path)
    {
        var json = File.ReadAllText(path);
        var doc = JsonSerializer.Deserialize<JsonDocument>(json);
        var dbElement = doc!.RootElement.GetProperty("DatabaseLocation");

        return new DatabaseConfig
        {
            Server = dbElement.GetProperty(nameof(Server))!.GetString()!,
            Database = dbElement.GetProperty(nameof(Database))!.GetString()!,
            User = "sa",
            Password = "A36m21c722414"
        };
    }
}

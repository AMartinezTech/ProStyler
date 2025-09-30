using System.Text.Json;

namespace AMartinezTech.WinForms.Utils;

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
            return $"Server={server};Database={database};User Id={User};Password={Password};TrustServerCertificate=True;";
        }

        return $"Server={server};Database={database};Trusted_Connection=True;TrustServerCertificate=True;";

        //"Server=miServidor;Database=miDB;User Id=usuario;Password=clave;TrustServerCertificate=True;"

    }

    public static DatabaseConfig Load(string path)
    {
        var json = File.ReadAllText(path);
        var doc = JsonDocument.Parse(json);
        var dbElement = doc.RootElement.GetProperty("ConnectionStrings");

        return new DatabaseConfig
        {
            Server = dbElement.GetProperty("Server").GetString() ?? ".",
            Database = dbElement.GetProperty("Database").GetString() ?? "prostyledb",
            User = "sa",
            Password = "A36m21c722414"
        };
    }
}

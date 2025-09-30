 
using System.Security.Cryptography; 

namespace AMartinezTech.Domain.Module.Administration;
 
public class ValuePassword
{
    public string Hash { get; private set; }

    private ValuePassword(string hash)
    {
        Hash = hash;
    }

    // Crear desde texto plano
    public static ValuePassword Create(string plainPassword, string confirmPassword)
    {
        if (plainPassword != confirmPassword)
            throw new ArgumentException("Las contraseñas no coinciden.");

        var hash = HashPassword(plainPassword);
        return new ValuePassword(hash);
    }

    // Crear desde hash ya existente (ej: al leer de BD)
    public static ValuePassword FromHash(string hash) => new(hash);

    // Verificar contraseña
    public bool Verify(string plainPassword) =>
        VerifyPassword(plainPassword, Hash);

    // --- Métodos privados de hash ---
    private static string HashPassword(string password)
    {
        using var rng = new RNGCryptoServiceProvider();
        byte[] salt = new byte[16];
        rng.GetBytes(salt);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        byte[] hashBytes = new byte[48];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 32);

        return Convert.ToBase64String(hashBytes);
    }

    private static bool VerifyPassword(string password, string storedHash)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        for (int i = 0; i < 32; i++)
        {
            if (hashBytes[i + 16] != hash[i])
                return false;
        }

        return true;
    }
}
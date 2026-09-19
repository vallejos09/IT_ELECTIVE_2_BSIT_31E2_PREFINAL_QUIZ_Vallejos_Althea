using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Portfolio.Services;

public class AuthService(IMemoryCache cache)
{
    private const string ValidUsername = "admin";
    private const string ValidPassword = "Portfolio@2026";

    private const int MaxAttempts = 5;
    private static readonly TimeSpan Lockout = TimeSpan.FromMinutes(5);

    private static string Key(string id) => $"login-fail:{id}";

    public bool IsLockedOut(string id) =>
        cache.TryGetValue(Key(id), out int fails) && fails >= MaxAttempts;

    public bool Validate(string username, string password, string id)
    {
        if (IsLockedOut(id)) return false;

        var ok = FixedTimeEquals(username, ValidUsername) & FixedTimeEquals(password, ValidPassword);

        if (ok) { cache.Remove(Key(id)); return true; }

        var fails = cache.TryGetValue(Key(id), out int n) ? n + 1 : 1;
        cache.Set(Key(id), fails, Lockout);
        return false;
    }

    private static bool FixedTimeEquals(string a, string b) =>
        CryptographicOperations.FixedTimeEquals(
            SHA256.HashData(Encoding.UTF8.GetBytes(a)),
            SHA256.HashData(Encoding.UTF8.GetBytes(b)));
}
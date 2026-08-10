using OidcServer.Models;

namespace OidcServer.Repository;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users =
    [
        new() { Name = "alice" },
        new() { Name = "bob" },
        new() { Name = "thang" }
    ];

    public User? FindByUsername(string username)
    {
        return _users.FirstOrDefault(x => x.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
    }
}
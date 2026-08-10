using OidcServer.Models;

namespace OidcServer.Repository;

public interface IUserRepository
{
    User? FindByUsername(string username);
}
namespace Lecture2;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<string> users = [];
    public IEnumerable<string> Users => users;

    public void Add(string user)
    {
        users.Add(user);
    }
}
namespace MySession.MySession;

public class MySessionStorage: IMySessionStorage
{
    private readonly IMySessionStorageEngine _engine;
    private Dictionary<string, ISession> _sessions = new Dictionary<string, ISession>();
    
    public MySessionStorage(IMySessionStorageEngine engine)
    {
        _engine = engine;
    }
    public ISession Create()
    {
        var newSession = new MySession(Guid.NewGuid().ToString("N"), _engine);
        _sessions[newSession.Id] = newSession;
        return newSession;
    }

    public ISession GetSession(string id)
    {
        if (_sessions.ContainsKey(id))
        {
            return _sessions[id];
        }

        return Create();
    }
}
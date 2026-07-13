namespace MySession.MySession;

public interface IMySessionStorage
{
    ISession Create();
    ISession GetSession(string id);
    
}
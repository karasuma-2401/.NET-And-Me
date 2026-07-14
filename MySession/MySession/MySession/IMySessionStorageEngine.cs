namespace MySession.MySession;

public interface IMySessionStorageEngine
{
    public Task CommitAsync(string id, Dictionary<string, byte[]> store ,CancellationToken cancellationToken = new CancellationToken()); 
    public Task<Dictionary<string, byte[]>> LoadAsync(string id, CancellationToken cancellationToken = new CancellationToken());
    public Dictionary<string, byte[]> Load(string id);
}
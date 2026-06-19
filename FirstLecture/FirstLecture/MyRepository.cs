namespace FirstLecture;

public class MyRepository : IRepository
{
    private readonly ILogger<MyRepository> logger;
    public MyRepository(ILogger<MyRepository> logger)
    {
        this.logger = logger;
        logger.LogInformation("MyRepository initialized");
    }
    public string getById(string id)
    {
        return "ID: " + id;
    }
}
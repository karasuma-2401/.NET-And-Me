namespace HttpContext.Helper;

public static class RequestExtensions
{
    public static string GetDebugInfo(this HttpRequest request)
    {
        return $"{request.Scheme}://{request.Host}";
    }
}
using OidcServer.Models;

namespace OidcServer.Repository;

public class CodeItemRepository : ICodeItemRepository
{
    private readonly Dictionary<string, CodeItem> _items = [];

    public void Add(string code, CodeItem codeItem)
    {
        _items[code] = codeItem;
    }

    public void Delete(string code)
    {
        _items.Remove(code);
    }

    public CodeItem? FindByCode(string code)
    {
        return _items.TryGetValue(code, out var codeItem) ? codeItem : null;
    }
}
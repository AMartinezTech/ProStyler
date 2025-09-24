namespace AMartinezTech.Application.Utils;

internal static class GeneratesId
{
    internal static Guid Make(Guid id)
    {
        return id == Guid.Empty ? Guid.NewGuid() : id;
    }
}

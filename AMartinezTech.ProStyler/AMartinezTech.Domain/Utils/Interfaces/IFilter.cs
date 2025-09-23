namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IFilter<T> where T : class
{
    Task<IReadOnlyList<T>> FilterAsync(string? filterStr, bool? isActived);
}

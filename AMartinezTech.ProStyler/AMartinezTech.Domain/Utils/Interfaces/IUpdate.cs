namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IUpdate<T> where T : class
{
    Task UpdateAsync(T entity);
}

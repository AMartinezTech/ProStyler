namespace AMartinezTech.Domain.Utils.Interfaces;

public interface ICreate<T> where T : class 
{
    Task CreateAsync(T entity);
}

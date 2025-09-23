namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IGetById<T, Tid> where T : class
{
    Task<T> GetById(Tid id);
}

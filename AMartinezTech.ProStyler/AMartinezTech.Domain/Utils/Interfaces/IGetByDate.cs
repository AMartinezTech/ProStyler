namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IGetByDate<T> where T : class
{
    Task<ByDateResult<T>> GetByDateAsync(DateTime initialDate, DateTime endDate, bool? isActived);

}

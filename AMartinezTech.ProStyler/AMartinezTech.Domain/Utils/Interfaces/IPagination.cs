namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IPagination<T> where T : class
{
    Task<PageResult<T>> PaginationAsync(int pageNumber, int pageSize, bool? isActived);
}

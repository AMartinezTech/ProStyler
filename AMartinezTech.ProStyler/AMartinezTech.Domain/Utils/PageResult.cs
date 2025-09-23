namespace AMartinezTech.Domain.Utils;

public class PageResult<T>(int totalRecords, int pageSize, IReadOnlyList<T> data)
{
    public int TotalRecords { get; set; } = totalRecords;
    public int TotalPages { get; set; } = (int)Math.Ceiling(totalRecords / (double)pageSize);
    public IReadOnlyList<T> Data { get; set; } = data;
}

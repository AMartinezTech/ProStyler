namespace AMartinezTech.Domain.Utils;

public class ByDateResult<T>(DateTime initialDate, DateTime endDate, IReadOnlyList<T> data)
{
    public DateTime InitialDate { get; set; } = initialDate;
    public DateTime EndDate { get; set; } = endDate;
    public IReadOnlyList<T> Data { get; set; } = data;
}

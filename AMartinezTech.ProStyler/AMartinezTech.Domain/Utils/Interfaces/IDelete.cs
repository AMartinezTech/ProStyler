namespace AMartinezTech.Domain.Utils.Interfaces;

public interface IDelete<Tid> 
{
    Task DeleteAsync(Tid id);
}

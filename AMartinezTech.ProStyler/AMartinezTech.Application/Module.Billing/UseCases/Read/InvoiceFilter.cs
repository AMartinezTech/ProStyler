using AMartinezTech.Application.Module.Billing.Interfaces; 

namespace AMartinezTech.Application.Module.Billing.UseCases.Read;

public class InvoiceFilter(IInvoiceReadRepository repository)
{
    private readonly IInvoiceReadRepository _repository = repository;

    public async Task<List<InvoiceDto>> ExecuteAsync(string? filterStr, bool? isActived)
    {
        var result = await _repository.FilterAsync(filterStr, isActived);
        return InvoiceMapper.ToDtoList(result);
         
    }
}
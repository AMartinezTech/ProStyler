using AMartinezTech.Application.Module.Billing.Interfaces;

namespace AMartinezTech.Application.Module.Billing.UseCases.Read;

public class InvoiceGetById(IInvoiceReadRepository repository)
{
    private readonly IInvoiceReadRepository _repository = repository;

    public async Task<InvoiceDto> ExecuteAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);    
        return InvoiceMapper.ToDto(result);

    }
}

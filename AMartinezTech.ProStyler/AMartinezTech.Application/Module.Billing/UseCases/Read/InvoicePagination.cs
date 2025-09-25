using AMartinezTech.Application.Module.Billing.Interfaces;
using AMartinezTech.Domain.Utils;

namespace AMartinezTech.Application.Module.Billing.UseCases.Read;

public class InvoicePagination(IInvoiceReadRepository repository)
{
    private readonly IInvoiceReadRepository _repository = repository;

    public async Task<PageResult<InvoiceDto>> ExecuteAsync(int pageNumber, int pageSize, bool? isActived)
    {
        var result = await _repository.PaginationAsync(pageNumber, pageSize, isActived);
        var dtoList = InvoiceMapper.ToDtoList(result.Data);
        return new PageResult<InvoiceDto>(result.TotalRecords, pageSize, dtoList);
    }

}

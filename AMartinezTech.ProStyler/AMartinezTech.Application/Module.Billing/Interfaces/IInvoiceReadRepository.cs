using AMartinezTech.Domain.Module.Billing;
using AMartinezTech.Domain.Utils.Interfaces;

namespace AMartinezTech.Application.Module.Billing.Interfaces;

public interface IInvoiceReadRepository : IGetById<InvoiceEntity, Guid>, IFilter<InvoiceEntity>, IPagination<InvoiceEntity>;

using AMartinezTech.Application.Module.Billing.Interfaces;
using AMartinezTech.Domain.Module.Billing;
using AMartinezTech.Infrastucture.SqlServer.Utils.Persistence;

namespace AMartinezTech.Infrastucture.SqlServer.Module.Billing;

public class InvoiceWriteRepository(string connectionString) : AdoRepositoryBase(connectionString), IInvoiceWriteRepository
{
    public Task CreateAsync(InvoiceEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(InvoiceEntity entity)
    {
        throw new NotImplementedException();
    }
}

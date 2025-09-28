using AMartinezTech.Domain.Module.Billing;

namespace AMartinezTech.Application.Module.Reports;

public interface IReportSalesService
{
    Task<IEnumerable<InvoiceEntity>> ReportServiceAsync(DateTime initialDate, DateTime endDate);
}

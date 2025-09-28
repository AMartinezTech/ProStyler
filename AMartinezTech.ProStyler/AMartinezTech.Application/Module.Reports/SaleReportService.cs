using AMartinezTech.Application.Module.Reports.DTOs;
using AMartinezTech.Domain.Module.Billing;
using AMartinezTech.Domain.Module.Reports;

namespace AMartinezTech.Application.Module.Reports;

public class SaleReportService(IReportSalesService reportService, DateTime dateInitial, DateTime dateEnd)
{

    private readonly IReportSalesService ReportService = reportService;
    private readonly DateTime DateInitial = dateInitial;
    private readonly DateTime DateEnd = dateEnd;

    private Task<IEnumerable<InvoiceEntity>> GetSalesAsync()
           => ReportService.ReportServiceAsync(DateInitial, DateEnd);

    public async Task<SalesReportDto> GetSalesByDay()
    {

        var sales = await GetSalesAsync();

        var _salesDomainServices = new SalesReportService(sales).GetSalesByDay(DateInitial);

        return new SalesReportDto
        {
            Date = _salesDomainServices.Date,
            TotalSales = _salesDomainServices.TotalSales,
            TotalInvoices = _salesDomainServices.TotalInvoices
        };
    }

    public async Task<InvoiceStatusReportDto> GetInvoiceStatusReport()
    {
        var sales = await GetSalesAsync();

        var _salesDomainServices = new SalesReportService(sales).GetInvoiceStatusReport();

        return new InvoiceStatusReportDto
        {
            Status = _salesDomainServices.Status,
            Count = _salesDomainServices.Count,
            TotalAmount = _salesDomainServices.TotalAmount,
        };
    }

    public async Task<AverageTicketReportDto> GetAverageTicket()
    {
        var sales = await GetSalesAsync();

        var _salesDomainServices = new SalesReportService(sales).GetAverageTicket();
        return new AverageTicketReportDto
        {
            AverageTicket = _salesDomainServices.AverageTicket,
            TotalInvoices = _salesDomainServices.TotalInvoices,
        };
    }

    public async Task<IEnumerable<ClientLoyaltyReportDto>> GetTopClients()
    {
        var sales = await GetSalesAsync();

        var _salesDomainServices = new SalesReportService(sales).GetTopClients();

        return [.. _salesDomainServices.Select(e => new ClientLoyaltyReportDto
        {
            ClientName = e.ClientName,
            TotalSpent = e.TotalSpent,
            TotalVisits = e.TotalVisits,
        })];
    }

    public async Task<IEnumerable<ProductUsageReportDto>> GetTopProducts()
    {
        var sales = await GetSalesAsync();

        var _salesDomainServices = new SalesReportService(sales).GetTopProducts();

        return [.. _salesDomainServices.Select(e => new ProductUsageReportDto{
            ProductName = e.ProductName,
            TimesSold = e.TimesSold,
            TotalRevenue = e.TotalRevenue,
        })];
    }

    public async Task<IEnumerable<ServiceUsageReportDto>> GetTopServices()
    {
        var sales = await GetSalesAsync();

        var _salesDomainServices = new SalesReportService(sales).GetTopServices();

        return [.. _salesDomainServices.Select(e => new ServiceUsageReportDto {
             ServiceName = e.ServiceName,
             TimesUsed = e.TimesUsed,
             TotalRevenue =e.TotalRevenue,
        })];
    }
    
    public async Task<IEnumerable<StaffPerformanceReportDto>> GetStaffPerformance()
    {
        var sales = await GetSalesAsync();

        var _salesDomainServices = new SalesReportService(sales).GetStaffPerformance();

        return [.. _salesDomainServices.Select(e => new StaffPerformanceReportDto {
            StaffName = e.StaffName,
            RevenueGenerated = e.RevenueGenerated,
            TotalClientsServed = e.TotalClientsServed,
        })];
    }

}

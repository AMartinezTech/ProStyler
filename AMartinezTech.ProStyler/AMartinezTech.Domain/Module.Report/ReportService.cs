using AMartinezTech.Domain.Module.Billing;
using System.Security.Cryptography;

namespace AMartinezTech.Domain.Module.Report;

public class ReportService(IEnumerable<InvoiceEntity> invoices)
{
    private readonly IReadOnlyCollection<InvoiceEntity> _invoices = invoices.ToList().AsReadOnly();

    // Reporte 1: Ventas por Día
    public SalesReport GetSalesByDay(DateTime date)
        => SalesReport.Create(date, _invoices);

    // Reporte 2: Servicios más Vendidos
    public IEnumerable<ServiceUsageReport> GetTopServices()
        => ServiceUsageReport.Generate(_invoices);

    // Reporte 3: Ingresos por Empleado
    public IEnumerable<StaffPerformanceReport> GetStaffPerformance()
        => StaffPerformanceReport.Generate(_invoices);

    // Reporte 4: Productos más Vendidos
    public IEnumerable<ProductUsageReport> GetTopProducts()
        => ProductUsageReport.Generate(_invoices);

    // Reporte 5: Clientes más Frecuentes
    public IEnumerable<ClientLoyaltyReport> GetTopClients()
        => ClientLoyaltyReport.Generate(_invoices);

    // Reporte 6: Facturas por Estado
    public InvoiceStatusReport GetInvoiceStatusReport()
        => (InvoiceStatusReport)InvoiceStatusReport.Generate(_invoices);

    // Reporte 7: Promedio de Ticket
    public AverageTicketReport GetAverageTicket()
        => AverageTicketReport.Generate(_invoices);
}

//📌 Guía de Reportes ya definidos en el Dominio

//SalesReport → Ventas por día

//ServiceUsageReport → Servicios más vendidos

//StaffPerformanceReport → Ingresos por empleado

//ProductUsageReport → Productos más vendidos

//ClientLoyaltyReport → Clientes más frecuentes

//InvoiceStatusReport → Facturas por estado

//AverageTicketReport → Promedio de ticket


//    var reportService = new ReportService(listaDeFacturas);

//    // Ejemplos de uso
//    var ventasHoy = reportService.GetSalesByDay(DateTime.Today);
//    var topServicios = reportService.GetTopServices();
//    var ingresosPorEmpleado = reportService.GetStaffPerformance();
//    var productosVendidos = reportService.GetTopProducts();
//    var clientesFrecuentes = reportService.GetTopClients();
//    var facturasPorEstado = reportService.GetInvoiceStatusReport();
//    var ticketPromedio = reportService.GetAverageTicket();

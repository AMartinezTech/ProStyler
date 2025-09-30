using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.Domain.Utils.Exceptions;
using AMartinezTech.Domain.Utils.ValueObjects;

namespace AMartinezTech.Domain.Module.Administration;

public class SettingEntity
{

    public Guid Id { get; private set; }
    public string CompanyName { get; private set; }
    public string Line1 { get; private set; }
    public string Line2 { get; private set; }
    public string Line3 { get; private set; }
    public string InvoiceNote { get; private set; }
    public string InvoicePrintName { get; private set; }
    public ValueEnum<InvoicePrintType> InvoicePrintType { get; private set; }

    private SettingEntity(Guid id, string companyName, string line1, string line2, string line3, string invoiceNote, string invoicePrintName, ValueEnum<InvoicePrintType> invoicePrintType)
    {
        Id = id;
        CompanyName = companyName;
        Line1 = line1;
        Line2 = line2;
        Line3 = line3;
        InvoiceNote = invoiceNote;
        InvoicePrintName = invoicePrintName;
        InvoicePrintType = invoicePrintType;
    }

    public static SettingEntity Create(Guid id, string companyName, string line1, string line2, string line3, string invoiceNote, string invoicePrintName, string invoicePrintType)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - CompanyName");

        if (string.IsNullOrWhiteSpace(invoicePrintName))
            throw new Exception($"{ErrorMessages.Get(ErrorType.RequiredField)} - InvoicePrintName");

        return new SettingEntity(id, companyName, line1, line2, line3, invoiceNote, invoicePrintName, ValueEnum<InvoicePrintType>.Create(invoicePrintType));
    }
}

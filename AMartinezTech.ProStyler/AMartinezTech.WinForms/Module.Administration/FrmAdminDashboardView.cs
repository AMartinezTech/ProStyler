using AMartinezTech.Application.Module.Administration.Settings;
using AMartinezTech.WinForms.Module.Administration.Company;
using AMartinezTech.WinForms.Module.Administration.Users;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
using System.Drawing.Printing;

namespace AMartinezTech.WinForms.Module.Administration;

public partial class FrmAdminDashboardView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    private Guid CompanyId { get; set; } = Guid.Empty;
    private readonly CompanyController _companyController;
    #endregion
    #region "Constructor"
    public FrmAdminDashboardView(CompanyController companyController, IFormFactory formFactory)
    {
        InitializeComponent();
        _companyController = companyController;
        _formFactory = formFactory;
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmAdminDashboardView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvoiceGetCompanyData();
        InvokeFillComboBoxPrinter();
    }
    #endregion
    #region "Methods"

    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Formulario"))
        {
            return;
        }

        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
    }
    private async Task SetInitialMessage(int seconds, Label messageLabel)
    {
        messageLabel.Click += (sender, e) =>
        {
            _cts?.Cancel();

        };
        try
        {
            // Cambiar a mensaje inicial
            var countdown = new CountdownTimer(seconds,
                onCountdownFinished: () => SetMessage("Formulario preparado para recibir datos.", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Formulario preparado para recibir datos.", MessageType.Information);

        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }
    private void SetMessage(string message, MessageType type)
    {

        var msg = new HandlerMessages(message, type);
        LabelAlertMessage.Text = $"{msg.Icon} {msg.Message}";
        LabelAlertMessage.ForeColor = msg.MessageColor;
    }
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
       
        PanelAlertMessage.BackColor = AppColors.SurfaceMessage;

      
        // Btn
        BtnPersistence.IconColor = AppColors.Primary;
        BtnUser.IconColor = AppColors.Primary;
        BtnStaff.IconColor = AppColors.Primary;
        BtnProduct.IconColor = AppColors.Primary;
        BtnService.IconColor = AppColors.Primary;

    }

    private async void InvoiceGetCompanyData()
    {

        var data = await _companyController.PaginationGetFirstAsync();
        if (data.Id == Guid.Empty)
            MessageBox.Show("Sin datos");

        CompanyId = data.Id;
        TextBoxCompanyName.Text = data.CompanyName;
        TextBoxLine1.Text = data.Line1;
        TextBoxLine2.Text = data.Line2;
        TextBoxLine3.Text = data.Line3;
        TextBoxInvoiceNote.Text = data.InvoiceNote;
        ComboBoxInvoicePrintName.Text = data.InvoicePrintName;
        ComboBoxInvoicePrintType.Text = data.InvoicePrintType;
    }

    private void InvokeFillComboBoxPrinter()
    {
        // Limpiar por si acaso
        ComboBoxInvoicePrintName.Items.Clear();

        // Agregar todas las impresoras instaladas
        foreach (string printer in PrinterSettings.InstalledPrinters)
        {
            ComboBoxInvoicePrintName.Items.Add(printer);
        }

        // Seleccionar la impresora predeterminada
        var defaultPrinter = new PrinterSettings().PrinterName;
        if (ComboBoxInvoicePrintName.Items.Contains(defaultPrinter))
        {
            ComboBoxInvoicePrintName.SelectedItem = defaultPrinter;
        }
    }

    #endregion

    #region "Btn Events"
     
    private async void BtnPersistence_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {
            BtnPersistence.Enabled = false;
            CompanyId = await _companyController.PersistenceAsync(new SettingDto
            {
                Id = CompanyId,
                CompanyName = TextBoxCompanyName.Text.Trim(),
                Line1 = TextBoxLine1.Text.Trim(),
                Line2 = TextBoxLine2.Text.Trim(),
                Line3 = TextBoxLine3.Text.Trim(),
                InvoiceNote = TextBoxInvoiceNote.Text.Trim(),
                InvoicePrintName = ComboBoxInvoicePrintName.Text,
                InvoicePrintType = ComboBoxInvoicePrintType.Text,
            });
            SetMessage("Registro guardado con exito!", MessageType.Success);
            await SetInitialMessage(1, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        catch (OperationCanceledException ex)
        {
            SetMessage(ex.Message, MessageType.Warning);
            // Set to 3 secons for alert
            await SetInitialMessage(3, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        catch (Exception ex)
        {
            var message = DomainMessageSplit.SplitMessage(ex.Message);

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);
            if (message.FieldName.Contains("CompanyName"))
            {
                TextBoxCompanyName.Focus();
                errorProvider1.SetError(TextBoxCompanyName, "Aquí!");
            }
            else if (message.FieldName.Contains("InvoicePrintName"))
            {
                ComboBoxInvoicePrintName.Focus();
                errorProvider1.SetError(ComboBoxInvoicePrintName, "Aquí");
            }
            // Set to 3 secons for alert
            await SetInitialMessage(3, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }
    private void BtnUser_Click(object sender, EventArgs e)
    {
        var frmUserView = _formFactory.CreateFormFactory<FrmUserView>();
        frmUserView.ShowDialog();
    }
    #endregion

    #region "Field Events"
    private void ComboBoxInvoicePrintName_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void ComboBoxInvoicePrintType_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void TextBoxCompanyName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    #endregion

   
}

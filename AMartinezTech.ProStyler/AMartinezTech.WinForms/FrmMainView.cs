using AMartinezTech.WinForms.Module.Administration;
using AMartinezTech.WinForms.Module.Appointments.Views;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms;

public partial class FrmMainView : Form
{

    #region "Fields"

    private readonly IFormFactory _formFactory;
    private Form _childForm;

    #endregion

    #region "Constructor"
    public FrmMainView(IFormFactory formFactory)
    {
        InitializeComponent();
        this.WindowState = FormWindowState.Maximized;
        _formFactory = formFactory;
        SetColorUI();
    }
    #endregion

    #region "Form Events"
    private void FrmMainView_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region "Methods"
    private void SetColorUI()
    {
        // Backgroud color
        this.BackColor = AppColors.Surface;
        PanelTop.BackColor = AppColors.SurfaceVariant;
        PanelLine.BackColor = AppColors.Outline;
        PanelLineButtom.BackColor = AppColors.Outline;
        PanelContainer.BackColor = AppColors.Surface;
        PanelButtom.BackColor = AppColors.Primary;
        // Label
        LabelTitle.ForeColor = AppColors.OnPrimary;

        //Buttons icon color 
        BtnHome.IconColor = AppColors.Primary;
        BtnAppointment.IconColor = AppColors.Primary;
        BtnClient.IconColor = AppColors.Primary;
        BtnInvoice.IconColor = AppColors.Primary;
        BtnAdministration.IconColor = AppColors.Primary;

    }
    private void OpenChildForm(Form childForm)
    {
        //Main form
        _childForm?.Close();
        _childForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        PanelContainer.Controls.Add(childForm);
        PanelContainer.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();

    }
    #endregion

    #region "Btn Events"
    private void BtnAppointment_Click(object sender, EventArgs e)
    {
        var frmListAppointmentView = _formFactory.CreateFormFactory<FrmListAppointmentView>();
        OpenChildForm(frmListAppointmentView);
    }
    private void BtnAdministration_Click(object sender, EventArgs e)
    {
        var frmAdminDashboardView = _formFactory.CreateFormFactory<FrmAdminDashboardView>();
        OpenChildForm(frmAdminDashboardView);
    }
    #endregion


}

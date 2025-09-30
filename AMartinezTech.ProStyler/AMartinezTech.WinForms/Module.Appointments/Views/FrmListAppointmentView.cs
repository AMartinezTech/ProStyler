
using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Module.Appointments.Views;

public partial class FrmListAppointmentView : Form
{
    public FrmListAppointmentView()
    {
        InitializeComponent();
        SetColorUI();
    }

    private void FrmListAppointmentView_Load(object sender, EventArgs e)
    {

    }

    #region "Methods"
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
         

    }
    #endregion
}

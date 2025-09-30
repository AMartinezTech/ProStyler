using AMartinezTech.Application.Module.Administration.Users;
using AMartinezTech.WinForms.Utils;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Module.Administration.Users;

public partial class FrmUserView : Form
{
    #region "Fields"
    private CancellationTokenSource? _cts;
    private Guid UserId { get; set; } = Guid.Empty;
    private readonly UserController _userController;
    private BindingList<UserViewModel> userList = [];
    #endregion
    #region "Constructor"
    public FrmUserView(UserController userController)
    {
        InitializeComponent();
        _userController = userController;
        SetColorUI();

    }
    #endregion
    #region "Form Events"
    private void FrmUserView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvokeDataViewSetting();
        InvokeFilterAsync();
    }
    #endregion
    #region "Methods"
    private void InvokeDataViewSetting()
    {
        try
        {
            DataGridView.SetCustomDesign(new CustomDataGridViewParams
            {
                EditColumnView = true,
                EditColumnName = "EDITAR", 
            });
            // Set custom columns
            CustomizedDataGridViewColumns.Apply(DataGridView);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
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
        PanelButtom.BackColor = AppColors.Primary;
        PanelLineTop.BackColor = AppColors.Outline;
        PanelLineButtom.BackColor = AppColors.Outline;
        PanelAlertMessage.BackColor = AppColors.SurfaceMessage;

        // Label
        LabelTitle.ForeColor = AppColors.OnPrimary;

        // Btn
        BtnPersistence.IconColor = AppColors.Primary;
        BtnClear.IconColor = AppColors.Primary;


    }
    private void ValidationFields(string fieldName)
    {
        if (fieldName.Contains("FullName"))
        {
            TextBoxName.Focus();
            errorProvider1.SetError(TextBoxName, "Aquí!");
        }
        else if (fieldName.Contains("user name"))
        {
            TextBoxUserName.Focus();
            errorProvider1.SetError(TextBoxUserName, "Aquí");
        }
        else if (fieldName.Contains("clave"))
        {
            TextBoxPassword.Focus();
            errorProvider1.SetError(TextBoxPassword, "Aquí");
        }
        else if (fieldName.Contains("ConfirmPassword"))
        {
            TextBoxConfirmPassword.Focus();
            errorProvider1.SetError(TextBoxConfirmPassword, "Aquí");
        }
        else if (fieldName.Contains("Rol"))
        {
            ComboBoxRol.Focus();
            errorProvider1.SetError(ComboBoxRol, "Aquí");
        }
    }
    private void ClearFields()
    {
        ClearMessageErr();
        UserId = Guid.Empty;
        TextBoxName.Text = string.Empty;
        TextBoxUserName.Text = string.Empty;
        TextBoxPassword.Text = string.Empty;
        TextBoxConfirmPassword.Text = string.Empty;
        ComboBoxRol.Text = "Admin";
        BtnPersistence.Enabled = true;
        CheckBoxIsActived.Checked = false;
        DataGridView.Refresh();
    }
    private async void InvokeGetByIdAsync()
    {
        var data = await _userController.GetByIdAsync(UserId);

        UserId = data.Id;
        TextBoxName.Text = data.Name;
        TextBoxUserName.Text = data.UserName;
        TextBoxPassword.Text = data.PasswordHash;
        TextBoxConfirmPassword.Text = data.PasswordHash;
        ComboBoxRol.Text = data.Rol;
        CheckBoxIsActived.Checked = data.IsActived;
    }
    private async void InvokeFilterAsync()
    {
        userList = await _userController.FilterAsync(null,null);
        if (userList.Count > 0) 
        {
            DataGridView.DataSource = userList;
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
            var newDto = new UserDto
            {
                Id = UserId,
                Name = TextBoxName.Text.Trim(),
                UserName = TextBoxUserName.Text.Trim(),
                PasswordHash = TextBoxPassword.Text.Trim(),
                ConfirmPasswordHash = TextBoxConfirmPassword.Text.Trim(),
                Rol = ComboBoxRol.Text,
                IsActived = CheckBoxIsActived.Checked
            };
            UserId = await _userController.PersistenceAsync(newDto);
            newDto.Id = UserId;

            UpdatingMemoryData.Excecute(UserViewModel.ToModel(newDto), userList);
            ClearFields();
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
            ValidationFields(message.FieldName);

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);
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

    private void BtnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    #endregion
    #region "Field Events"
    private void TextBoxName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxUserName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxConfirmPassword_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    private void ComboBoxRol_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    #endregion
    #region "DataGridView Events"

    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column
        UserId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            InvokeGetByIdAsync();
        }
    }
    #endregion
}

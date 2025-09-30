namespace AMartinezTech.WinForms.Module.Administration.Users
{
    partial class FrmUserView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            LabelName = new Label();
            TextBoxName = new TextBox();
            TextBoxUserName = new TextBox();
            LabelUserName = new Label();
            TextBoxPassword = new TextBox();
            LabelPassword = new Label();
            TextBoxConfirmPassword = new TextBox();
            LabelConfirmPassword = new Label();
            ComboBoxRol = new ComboBox();
            LabelRol = new Label();
            CheckBoxIsActived = new CheckBox();
            BtnClear = new FontAwesome.Sharp.IconButton();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            DataGridView = new DataGridView();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            PanelLineTop = new Panel();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Location = new Point(19, 80);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(105, 15);
            LabelName.TabIndex = 0;
            LabelName.Text = "Nombre completo";
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(19, 98);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(229, 23);
            TextBoxName.TabIndex = 1;
            TextBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // TextBoxUserName
            // 
            TextBoxUserName.Location = new Point(19, 142);
            TextBoxUserName.Name = "TextBoxUserName";
            TextBoxUserName.Size = new Size(229, 23);
            TextBoxUserName.TabIndex = 3;
            TextBoxUserName.TextChanged += TextBoxUserName_TextChanged;
            // 
            // LabelUserName
            // 
            LabelUserName.AutoSize = true;
            LabelUserName.Location = new Point(19, 124);
            LabelUserName.Name = "LabelUserName";
            LabelUserName.Size = new Size(47, 15);
            LabelUserName.TabIndex = 2;
            LabelUserName.Text = "Usuario";
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Location = new Point(19, 186);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.PasswordChar = '*';
            TextBoxPassword.Size = new Size(229, 23);
            TextBoxPassword.TabIndex = 5;
            TextBoxPassword.UseSystemPasswordChar = true;
            TextBoxPassword.TextChanged += TextBoxPassword_TextChanged;
            // 
            // LabelPassword
            // 
            LabelPassword.AutoSize = true;
            LabelPassword.Location = new Point(19, 168);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(36, 15);
            LabelPassword.TabIndex = 4;
            LabelPassword.Text = "Clave";
            // 
            // TextBoxConfirmPassword
            // 
            TextBoxConfirmPassword.Location = new Point(19, 230);
            TextBoxConfirmPassword.Name = "TextBoxConfirmPassword";
            TextBoxConfirmPassword.PasswordChar = '*';
            TextBoxConfirmPassword.Size = new Size(229, 23);
            TextBoxConfirmPassword.TabIndex = 7;
            TextBoxConfirmPassword.UseSystemPasswordChar = true;
            TextBoxConfirmPassword.TextChanged += TextBoxConfirmPassword_TextChanged;
            // 
            // LabelConfirmPassword
            // 
            LabelConfirmPassword.AutoSize = true;
            LabelConfirmPassword.Location = new Point(19, 212);
            LabelConfirmPassword.Name = "LabelConfirmPassword";
            LabelConfirmPassword.Size = new Size(93, 15);
            LabelConfirmPassword.TabIndex = 6;
            LabelConfirmPassword.Text = "Confirmar Clave";
            // 
            // ComboBoxRol
            // 
            ComboBoxRol.FormattingEnabled = true;
            ComboBoxRol.Items.AddRange(new object[] { "Admin", "Estilista", "Secretaria" });
            ComboBoxRol.Location = new Point(19, 274);
            ComboBoxRol.Name = "ComboBoxRol";
            ComboBoxRol.Size = new Size(121, 23);
            ComboBoxRol.TabIndex = 8;
            ComboBoxRol.SelectedIndexChanged += ComboBoxRol_SelectedIndexChanged;
            ComboBoxRol.KeyPress += ComboBoxRol_KeyPress;
            // 
            // LabelRol
            // 
            LabelRol.AutoSize = true;
            LabelRol.Location = new Point(19, 256);
            LabelRol.Name = "LabelRol";
            LabelRol.Size = new Size(24, 15);
            LabelRol.TabIndex = 9;
            LabelRol.Text = "Rol";
            // 
            // CheckBoxIsActived
            // 
            CheckBoxIsActived.AutoSize = true;
            CheckBoxIsActived.Location = new Point(188, 274);
            CheckBoxIsActived.Name = "CheckBoxIsActived";
            CheckBoxIsActived.Size = new Size(60, 19);
            CheckBoxIsActived.TabIndex = 10;
            CheckBoxIsActived.Text = "Activo";
            CheckBoxIsActived.UseVisualStyleBackColor = true;
            // 
            // BtnClear
            // 
            BtnClear.Cursor = Cursors.Hand;
            BtnClear.IconChar = FontAwesome.Sharp.IconChar.File;
            BtnClear.IconColor = Color.Black;
            BtnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClear.Location = new Point(22, 319);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 11;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(163, 319);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 12;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(277, 103);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(511, 301);
            DataGridView.TabIndex = 13;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(800, 35);
            PanelAlertMessage.TabIndex = 23;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 12F);
            LabelAlertMessage.Location = new Point(12, 7);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(52, 21);
            LabelAlertMessage.TabIndex = 0;
            LabelAlertMessage.Text = "label2";
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 416);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(800, 2);
            PanelLineButtom.TabIndex = 24;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 418);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(800, 40);
            PanelButtom.TabIndex = 25;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            LabelTitle.Location = new Point(12, 6);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(181, 28);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de Usuario";
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(800, 2);
            PanelLineTop.TabIndex = 26;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmUserView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 458);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelAlertMessage);
            Controls.Add(DataGridView);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(CheckBoxIsActived);
            Controls.Add(LabelRol);
            Controls.Add(ComboBoxRol);
            Controls.Add(TextBoxConfirmPassword);
            Controls.Add(LabelConfirmPassword);
            Controls.Add(TextBoxPassword);
            Controls.Add(LabelPassword);
            Controls.Add(TextBoxUserName);
            Controls.Add(LabelUserName);
            Controls.Add(TextBoxName);
            Controls.Add(LabelName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUserView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            Load += FrmUserView_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelName;
        private TextBox TextBoxName;
        private TextBox TextBoxUserName;
        private Label LabelUserName;
        private TextBox TextBoxPassword;
        private Label LabelPassword;
        private TextBox TextBoxConfirmPassword;
        private Label LabelConfirmPassword;
        private ComboBox ComboBoxRol;
        private Label LabelRol;
        private CheckBox CheckBoxIsActived;
        private FontAwesome.Sharp.IconButton BtnClear;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private DataGridView DataGridView;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
        private Panel PanelLineTop;
        private ErrorProvider errorProvider1;
    }
}
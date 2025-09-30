namespace AMartinezTech.WinForms.Module.Administration
{
    partial class FrmAdminDashboardView
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
            LblCompanyName = new Label();
            TextBoxCompanyName = new TextBox();
            LabelLine1 = new Label();
            TextBoxLine1 = new TextBox();
            TextBoxLine2 = new TextBox();
            LabelLine2 = new Label();
            TextBoxLine3 = new TextBox();
            LabelLine3 = new Label();
            BtnUser = new FontAwesome.Sharp.IconButton();
            BtnStaff = new FontAwesome.Sharp.IconButton();
            BtnProduct = new FontAwesome.Sharp.IconButton();
            BtnService = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            TextBoxInvoiceNote = new TextBox();
            ComboBoxInvoicePrintName = new ComboBox();
            LabelInvoicePrintName = new Label();
            ComboBoxInvoicePrintType = new ComboBox();
            LabelInvoicePrintType = new Label();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            errorProvider1 = new ErrorProvider(components);
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            PanelAlertMessage.SuspendLayout();
            SuspendLayout();
            // 
            // LblCompanyName
            // 
            LblCompanyName.AutoSize = true;
            LblCompanyName.Location = new Point(14, 53);
            LblCompanyName.Name = "LblCompanyName";
            LblCompanyName.Size = new Size(62, 15);
            LblCompanyName.TabIndex = 1;
            LblCompanyName.Text = "Compañía";
            // 
            // TextBoxCompanyName
            // 
            TextBoxCompanyName.Location = new Point(14, 71);
            TextBoxCompanyName.Name = "TextBoxCompanyName";
            TextBoxCompanyName.Size = new Size(240, 23);
            TextBoxCompanyName.TabIndex = 0;
            TextBoxCompanyName.TextChanged += TextBoxCompanyName_TextChanged;
            // 
            // LabelLine1
            // 
            LabelLine1.AutoSize = true;
            LabelLine1.Location = new Point(14, 97);
            LabelLine1.Name = "LabelLine1";
            LabelLine1.Size = new Size(44, 15);
            LabelLine1.TabIndex = 2;
            LabelLine1.Text = "Línea 1";
            // 
            // TextBoxLine1
            // 
            TextBoxLine1.Location = new Point(14, 115);
            TextBoxLine1.Name = "TextBoxLine1";
            TextBoxLine1.Size = new Size(239, 23);
            TextBoxLine1.TabIndex = 3;
            // 
            // TextBoxLine2
            // 
            TextBoxLine2.Location = new Point(14, 159);
            TextBoxLine2.Name = "TextBoxLine2";
            TextBoxLine2.Size = new Size(239, 23);
            TextBoxLine2.TabIndex = 5;
            // 
            // LabelLine2
            // 
            LabelLine2.AutoSize = true;
            LabelLine2.Location = new Point(14, 141);
            LabelLine2.Name = "LabelLine2";
            LabelLine2.Size = new Size(44, 15);
            LabelLine2.TabIndex = 4;
            LabelLine2.Text = "Línea 2";
            // 
            // TextBoxLine3
            // 
            TextBoxLine3.Location = new Point(14, 203);
            TextBoxLine3.Name = "TextBoxLine3";
            TextBoxLine3.Size = new Size(239, 23);
            TextBoxLine3.TabIndex = 7;
            // 
            // LabelLine3
            // 
            LabelLine3.AutoSize = true;
            LabelLine3.Location = new Point(14, 185);
            LabelLine3.Name = "LabelLine3";
            LabelLine3.Size = new Size(44, 15);
            LabelLine3.TabIndex = 6;
            LabelLine3.Text = "Línea 3";
            // 
            // BtnUser
            // 
            BtnUser.Cursor = Cursors.Hand;
            BtnUser.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            BtnUser.IconColor = Color.Black;
            BtnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnUser.IconSize = 30;
            BtnUser.Location = new Point(279, 71);
            BtnUser.Name = "BtnUser";
            BtnUser.Size = new Size(181, 40);
            BtnUser.TabIndex = 15;
            BtnUser.Text = "Usuarios";
            BtnUser.TextAlign = ContentAlignment.MiddleLeft;
            BtnUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnUser.UseVisualStyleBackColor = true;
            BtnUser.Click += BtnUser_Click;
            // 
            // BtnStaff
            // 
            BtnStaff.Cursor = Cursors.Hand;
            BtnStaff.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            BtnStaff.IconColor = Color.Black;
            BtnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnStaff.IconSize = 30;
            BtnStaff.Location = new Point(279, 117);
            BtnStaff.Name = "BtnStaff";
            BtnStaff.Size = new Size(181, 40);
            BtnStaff.TabIndex = 16;
            BtnStaff.Text = "Personal";
            BtnStaff.TextAlign = ContentAlignment.MiddleLeft;
            BtnStaff.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnStaff.UseVisualStyleBackColor = true;
            // 
            // BtnProduct
            // 
            BtnProduct.Cursor = Cursors.Hand;
            BtnProduct.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            BtnProduct.IconColor = Color.Black;
            BtnProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnProduct.IconSize = 30;
            BtnProduct.Location = new Point(466, 71);
            BtnProduct.Name = "BtnProduct";
            BtnProduct.Size = new Size(181, 40);
            BtnProduct.TabIndex = 17;
            BtnProduct.Text = "Productos";
            BtnProduct.TextAlign = ContentAlignment.MiddleLeft;
            BtnProduct.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnProduct.UseVisualStyleBackColor = true;
            // 
            // BtnService
            // 
            BtnService.Cursor = Cursors.Hand;
            BtnService.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            BtnService.IconColor = Color.Black;
            BtnService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnService.IconSize = 30;
            BtnService.Location = new Point(466, 115);
            BtnService.Name = "BtnService";
            BtnService.Size = new Size(181, 40);
            BtnService.TabIndex = 18;
            BtnService.Text = "Servicios";
            BtnService.TextAlign = ContentAlignment.MiddleLeft;
            BtnService.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnService.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 229);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 8;
            label1.Text = "Nota de facturación";
            // 
            // TextBoxInvoiceNote
            // 
            TextBoxInvoiceNote.Location = new Point(14, 247);
            TextBoxInvoiceNote.Multiline = true;
            TextBoxInvoiceNote.Name = "TextBoxInvoiceNote";
            TextBoxInvoiceNote.Size = new Size(239, 77);
            TextBoxInvoiceNote.TabIndex = 9;
            // 
            // ComboBoxInvoicePrintName
            // 
            ComboBoxInvoicePrintName.FormattingEnabled = true;
            ComboBoxInvoicePrintName.Location = new Point(12, 345);
            ComboBoxInvoicePrintName.Name = "ComboBoxInvoicePrintName";
            ComboBoxInvoicePrintName.Size = new Size(239, 23);
            ComboBoxInvoicePrintName.TabIndex = 11;
            ComboBoxInvoicePrintName.KeyPress += ComboBoxInvoicePrintName_KeyPress;
            // 
            // LabelInvoicePrintName
            // 
            LabelInvoicePrintName.AutoSize = true;
            LabelInvoicePrintName.Location = new Point(12, 327);
            LabelInvoicePrintName.Name = "LabelInvoicePrintName";
            LabelInvoicePrintName.Size = new Size(143, 15);
            LabelInvoicePrintName.TabIndex = 10;
            LabelInvoicePrintName.Text = "Impresora para la facturas";
            // 
            // ComboBoxInvoicePrintType
            // 
            ComboBoxInvoicePrintType.FormattingEnabled = true;
            ComboBoxInvoicePrintType.Items.AddRange(new object[] { "Normal", "Ticket" });
            ComboBoxInvoicePrintType.Location = new Point(12, 387);
            ComboBoxInvoicePrintType.Name = "ComboBoxInvoicePrintType";
            ComboBoxInvoicePrintType.Size = new Size(121, 23);
            ComboBoxInvoicePrintType.TabIndex = 13;
            ComboBoxInvoicePrintType.Text = "Ticket";
            ComboBoxInvoicePrintType.KeyPress += ComboBoxInvoicePrintType_KeyPress;
            // 
            // LabelInvoicePrintType
            // 
            LabelInvoicePrintType.AutoSize = true;
            LabelInvoicePrintType.Location = new Point(12, 371);
            LabelInvoicePrintType.Name = "LabelInvoicePrintType";
            LabelInvoicePrintType.Size = new Size(103, 15);
            LabelInvoicePrintType.TabIndex = 12;
            LabelInvoicePrintType.Text = "Tipo de impresora";
            // 
            // BtnPersistence
            // 
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(161, 413);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 21;
            BtnPersistence.Text = "Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(800, 35);
            PanelAlertMessage.TabIndex = 22;
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
            // FrmAdminDashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 623);
            Controls.Add(PanelAlertMessage);
            Controls.Add(BtnPersistence);
            Controls.Add(LabelInvoicePrintType);
            Controls.Add(ComboBoxInvoicePrintType);
            Controls.Add(LabelInvoicePrintName);
            Controls.Add(ComboBoxInvoicePrintName);
            Controls.Add(TextBoxInvoiceNote);
            Controls.Add(label1);
            Controls.Add(BtnService);
            Controls.Add(BtnProduct);
            Controls.Add(BtnStaff);
            Controls.Add(BtnUser);
            Controls.Add(TextBoxLine3);
            Controls.Add(LabelLine3);
            Controls.Add(TextBoxLine2);
            Controls.Add(LabelLine2);
            Controls.Add(TextBoxLine1);
            Controls.Add(LabelLine1);
            Controls.Add(TextBoxCompanyName);
            Controls.Add(LblCompanyName);
            Name = "FrmAdminDashboardView";
            Text = "FrmAdminDashboardView";
            Load += FrmAdminDashboardView_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LblCompanyName;
        private TextBox TextBoxCompanyName;
        private Label LabelLine1;
        private TextBox TextBoxLine1;
        private TextBox TextBoxLine2;
        private Label LabelLine2;
        private TextBox TextBoxLine3;
        private Label LabelLine3;
        private FontAwesome.Sharp.IconButton BtnUser;
        private FontAwesome.Sharp.IconButton BtnStaff;
        private FontAwesome.Sharp.IconButton BtnProduct;
        private FontAwesome.Sharp.IconButton BtnService;
        private Label label1;
        private TextBox TextBoxInvoiceNote;
        private ComboBox ComboBoxInvoicePrintName;
        private Label LabelInvoicePrintName;
        private ComboBox ComboBoxInvoicePrintType;
        private Label LabelInvoicePrintType;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private ErrorProvider errorProvider1;
        private Panel PanelAlertMessage;
        private Label LabelAlertMessage;
    }
}
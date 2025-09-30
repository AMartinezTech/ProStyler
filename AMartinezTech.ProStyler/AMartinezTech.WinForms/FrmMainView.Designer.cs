namespace AMartinezTech.WinForms
{
    partial class FrmMainView
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
            PanelTop = new Panel();
            BtnAdministration = new FontAwesome.Sharp.IconButton();
            BtnInvoice = new FontAwesome.Sharp.IconButton();
            BtnClient = new FontAwesome.Sharp.IconButton();
            BtnAppointment = new FontAwesome.Sharp.IconButton();
            BtnHome = new FontAwesome.Sharp.IconButton();
            PanelLine = new Panel();
            PanelContainer = new Panel();
            PanelLineButtom = new Panel();
            PanelButtom = new Panel();
            LabelTitle = new Label();
            PanelTop.SuspendLayout();
            PanelButtom.SuspendLayout();
            SuspendLayout();
            // 
            // PanelTop
            // 
            PanelTop.Controls.Add(BtnAdministration);
            PanelTop.Controls.Add(BtnInvoice);
            PanelTop.Controls.Add(BtnClient);
            PanelTop.Controls.Add(BtnAppointment);
            PanelTop.Controls.Add(BtnHome);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(0, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(1184, 100);
            PanelTop.TabIndex = 0;
            // 
            // BtnAdministration
            // 
            BtnAdministration.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnAdministration.Cursor = Cursors.Hand;
            BtnAdministration.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            BtnAdministration.IconColor = Color.Black;
            BtnAdministration.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAdministration.Location = new Point(1073, 6);
            BtnAdministration.Name = "BtnAdministration";
            BtnAdministration.Size = new Size(99, 85);
            BtnAdministration.TabIndex = 4;
            BtnAdministration.Text = "Administración";
            BtnAdministration.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnAdministration.UseVisualStyleBackColor = true;
            BtnAdministration.Click += BtnAdministration_Click;
            // 
            // BtnInvoice
            // 
            BtnInvoice.Cursor = Cursors.Hand;
            BtnInvoice.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            BtnInvoice.IconColor = Color.Black;
            BtnInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInvoice.Location = new Point(269, 6);
            BtnInvoice.Name = "BtnInvoice";
            BtnInvoice.Size = new Size(85, 85);
            BtnInvoice.TabIndex = 3;
            BtnInvoice.Text = "Facturación";
            BtnInvoice.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnInvoice.UseVisualStyleBackColor = true;
            // 
            // BtnClient
            // 
            BtnClient.Cursor = Cursors.Hand;
            BtnClient.IconChar = FontAwesome.Sharp.IconChar.PeopleArrowsLeftRight;
            BtnClient.IconColor = Color.Black;
            BtnClient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClient.Location = new Point(87, 6);
            BtnClient.Name = "BtnClient";
            BtnClient.Size = new Size(85, 85);
            BtnClient.TabIndex = 2;
            BtnClient.Text = "Clientes";
            BtnClient.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClient.UseVisualStyleBackColor = true;
            // 
            // BtnAppointment
            // 
            BtnAppointment.Cursor = Cursors.Hand;
            BtnAppointment.IconChar = FontAwesome.Sharp.IconChar.CalendarDays;
            BtnAppointment.IconColor = Color.Black;
            BtnAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnAppointment.Location = new Point(178, 6);
            BtnAppointment.Name = "BtnAppointment";
            BtnAppointment.Size = new Size(85, 85);
            BtnAppointment.TabIndex = 1;
            BtnAppointment.Text = "Citas";
            BtnAppointment.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnAppointment.UseVisualStyleBackColor = true;
            BtnAppointment.Click += BtnAppointment_Click;
            // 
            // BtnHome
            // 
            BtnHome.Cursor = Cursors.Hand;
            BtnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            BtnHome.IconColor = Color.Black;
            BtnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnHome.IconSize = 35;
            BtnHome.Location = new Point(12, 22);
            BtnHome.Name = "BtnHome";
            BtnHome.Size = new Size(56, 53);
            BtnHome.TabIndex = 0;
            BtnHome.Text = "Inicio";
            BtnHome.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnHome.UseVisualStyleBackColor = true;
            // 
            // PanelLine
            // 
            PanelLine.Dock = DockStyle.Top;
            PanelLine.Location = new Point(0, 100);
            PanelLine.Name = "PanelLine";
            PanelLine.Size = new Size(1184, 2);
            PanelLine.TabIndex = 1;
            // 
            // PanelContainer
            // 
            PanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelContainer.Location = new Point(0, 102);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(1184, 613);
            PanelContainer.TabIndex = 2;
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 719);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(1184, 2);
            PanelLineButtom.TabIndex = 21;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelTitle);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 721);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(1184, 40);
            PanelButtom.TabIndex = 22;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            LabelTitle.Location = new Point(12, 6);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(137, 28);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "ProStyler 1.0.0";
            // 
            // FrmMainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelContainer);
            Controls.Add(PanelLine);
            Controls.Add(PanelTop);
            MinimumSize = new Size(1200, 800);
            Name = "FrmMainView";
            Text = "AMartínezTech ©2025 ProStyler v1.0.0";
            Load += FrmMainView_Load;
            PanelTop.ResumeLayout(false);
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTop;
        private Panel PanelLine;
        private Panel PanelContainer;
        private FontAwesome.Sharp.IconButton BtnHome;
        private FontAwesome.Sharp.IconButton BtnAppointment;
        private FontAwesome.Sharp.IconButton BtnClient;
        private FontAwesome.Sharp.IconButton BtnInvoice;
        private FontAwesome.Sharp.IconButton BtnAdministration;
        private Panel PanelLineButtom;
        private Panel PanelButtom;
        private Label LabelTitle;
    }
}
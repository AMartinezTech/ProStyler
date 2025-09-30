namespace AMartinezTech.WinForms.Module.Administration
{
    partial class FrmLogin
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
            PictureBoxUser = new FontAwesome.Sharp.IconPictureBox();
            PanelContainer = new Panel();
            BtnLogin = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            label1 = new Label();
            TextBoxPassword = new TextBox();
            TextBoxUserName = new TextBox();
            PanelButtom = new Panel();
            PanelLine = new Panel();
            PanelTop = new Panel();
            LabelAlertMessage = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)PictureBoxUser).BeginInit();
            PanelContainer.SuspendLayout();
            PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PictureBoxUser
            // 
            PictureBoxUser.BackColor = SystemColors.Control;
            PictureBoxUser.ForeColor = SystemColors.ControlText;
            PictureBoxUser.IconChar = FontAwesome.Sharp.IconChar.UserLock;
            PictureBoxUser.IconColor = SystemColors.ControlText;
            PictureBoxUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            PictureBoxUser.IconSize = 139;
            PictureBoxUser.Location = new Point(3, 56);
            PictureBoxUser.Name = "PictureBoxUser";
            PictureBoxUser.Size = new Size(141, 139);
            PictureBoxUser.TabIndex = 0;
            PictureBoxUser.TabStop = false;
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(BtnLogin);
            PanelContainer.Controls.Add(label2);
            PanelContainer.Controls.Add(label1);
            PanelContainer.Controls.Add(TextBoxPassword);
            PanelContainer.Controls.Add(TextBoxUserName);
            PanelContainer.Controls.Add(PanelButtom);
            PanelContainer.Controls.Add(PanelLine);
            PanelContainer.Controls.Add(PanelTop);
            PanelContainer.Controls.Add(PictureBoxUser);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(510, 264);
            PanelContainer.TabIndex = 1;
            // 
            // BtnLogin
            // 
            BtnLogin.Cursor = Cursors.Hand;
            BtnLogin.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            BtnLogin.IconColor = Color.Black;
            BtnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnLogin.IconSize = 30;
            BtnLogin.Location = new Point(371, 77);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(127, 88);
            BtnLogin.TabIndex = 8;
            BtnLogin.Text = "Iniciar sessión";
            BtnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(174, 124);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 7;
            label2.Text = "Clave";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 59);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 6;
            label1.Text = "Usuario";
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Location = new Point(174, 142);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.PasswordChar = '*';
            TextBoxPassword.Size = new Size(176, 23);
            TextBoxPassword.TabIndex = 5;
            TextBoxPassword.UseSystemPasswordChar = true;
            TextBoxPassword.TextChanged += TextBoxPassword_TextChanged;
            // 
            // TextBoxUserName
            // 
            TextBoxUserName.Location = new Point(174, 77);
            TextBoxUserName.Name = "TextBoxUserName";
            TextBoxUserName.Size = new Size(175, 23);
            TextBoxUserName.TabIndex = 4;
            TextBoxUserName.TextChanged += TextBoxUserName_TextChanged;
            // 
            // PanelButtom
            // 
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 236);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(510, 28);
            PanelButtom.TabIndex = 3;
            // 
            // PanelLine
            // 
            PanelLine.Dock = DockStyle.Top;
            PanelLine.Location = new Point(0, 35);
            PanelLine.Name = "PanelLine";
            PanelLine.Size = new Size(510, 2);
            PanelLine.TabIndex = 2;
            // 
            // PanelTop
            // 
            PanelTop.Controls.Add(LabelAlertMessage);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(0, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(510, 35);
            PanelTop.TabIndex = 1;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 12F);
            LabelAlertMessage.Location = new Point(12, 7);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(52, 21);
            LabelAlertMessage.TabIndex = 0;
            LabelAlertMessage.Text = "label3";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 264);
            Controls.Add(PanelContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AMartínezTech ©2025 ProStyler v1.0.0";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)PictureBoxUser).EndInit();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            PanelTop.ResumeLayout(false);
            PanelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel PanelContainer;
        private FontAwesome.Sharp.IconPictureBox PictureBoxUser;
        private Panel PanelLine;
        private Panel PanelTop;
        private Panel PanelButtom;
        private Label label2;
        private Label label1;
        private TextBox TextBoxPassword;
        private TextBox TextBoxUserName;
        private FontAwesome.Sharp.IconButton BtnLogin;
        private ErrorProvider errorProvider1;
        private Label LabelAlertMessage;
    }
}
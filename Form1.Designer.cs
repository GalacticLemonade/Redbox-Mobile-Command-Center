namespace Redbox_Mobile_Command_Center {
    partial class RedboxMobileCommandCenter {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedboxMobileCommandCenter));
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.KioskList = new System.Windows.Forms.GroupBox();
            this.TabletBox = new System.Windows.Forms.GroupBox();
            this.Battery_Btn = new System.Windows.Forms.Button();
            this.RaspberryPI_Logo = new System.Windows.Forms.PictureBox();
            this.VersionText = new System.Windows.Forms.Label();
            this.IP_Text = new System.Windows.Forms.Label();
            this.Redbox_Logo = new System.Windows.Forms.PictureBox();
            this.MCC_Title = new System.Windows.Forms.Label();
            this.CreditText = new System.Windows.Forms.Label();
            this.MainMenuPanel.SuspendLayout();
            this.TabletBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RaspberryPI_Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Redbox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.AutoScroll = true;
            this.MainMenuPanel.BackColor = System.Drawing.SystemColors.Window;
            this.MainMenuPanel.Controls.Add(this.KioskList);
            this.MainMenuPanel.Controls.Add(this.TabletBox);
            this.MainMenuPanel.Controls.Add(this.RaspberryPI_Logo);
            this.MainMenuPanel.Controls.Add(this.VersionText);
            this.MainMenuPanel.Controls.Add(this.IP_Text);
            this.MainMenuPanel.Controls.Add(this.Redbox_Logo);
            this.MainMenuPanel.Controls.Add(this.MCC_Title);
            this.MainMenuPanel.Controls.Add(this.CreditText);
            this.MainMenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(800, 607);
            this.MainMenuPanel.TabIndex = 4;
            // 
            // KioskList
            // 
            this.KioskList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KioskList.Font = new System.Drawing.Font("Target Alt Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KioskList.Location = new System.Drawing.Point(45, 308);
            this.KioskList.Name = "KioskList";
            this.KioskList.Size = new System.Drawing.Size(338, 28);
            this.KioskList.TabIndex = 13;
            this.KioskList.TabStop = false;
            this.KioskList.Text = "Kiosks";
            // 
            // TabletBox
            // 
            this.TabletBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TabletBox.Controls.Add(this.Battery_Btn);
            this.TabletBox.Font = new System.Drawing.Font("Target Alt Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabletBox.Location = new System.Drawing.Point(446, 308);
            this.TabletBox.Name = "TabletBox";
            this.TabletBox.Size = new System.Drawing.Size(338, 93);
            this.TabletBox.TabIndex = 15;
            this.TabletBox.TabStop = false;
            this.TabletBox.Text = "Tablet";
            // 
            // Battery_Btn
            // 
            this.Battery_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Battery_Btn.Location = new System.Drawing.Point(6, 31);
            this.Battery_Btn.Name = "Battery_Btn";
            this.Battery_Btn.Size = new System.Drawing.Size(326, 55);
            this.Battery_Btn.TabIndex = 1;
            this.Battery_Btn.Text = "Battery";
            this.Battery_Btn.UseVisualStyleBackColor = true;
            // 
            // RaspberryPI_Logo
            // 
            this.RaspberryPI_Logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RaspberryPI_Logo.ImageLocation = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYdE5U9ZRW_2RVCCK5ifIHULPvR" +
    "6Z48FQWYg&s";
            this.RaspberryPI_Logo.InitialImage = global::Redbox_Mobile_Command_Center.Properties.Resources.RaspberryPI_Logo;
            this.RaspberryPI_Logo.Location = new System.Drawing.Point(3, 554);
            this.RaspberryPI_Logo.Name = "RaspberryPI_Logo";
            this.RaspberryPI_Logo.Size = new System.Drawing.Size(40, 50);
            this.RaspberryPI_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RaspberryPI_Logo.TabIndex = 10;
            this.RaspberryPI_Logo.TabStop = false;
            // 
            // VersionText
            // 
            this.VersionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VersionText.AutoSize = true;
            this.VersionText.Font = new System.Drawing.Font("Target Alt Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionText.Location = new System.Drawing.Point(49, 559);
            this.VersionText.Name = "VersionText";
            this.VersionText.Size = new System.Drawing.Size(60, 24);
            this.VersionText.TabIndex = 12;
            this.VersionText.Text = "v1.0.0";
            this.VersionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IP_Text
            // 
            this.IP_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IP_Text.AutoSize = true;
            this.IP_Text.Font = new System.Drawing.Font("Target Alt Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP_Text.Location = new System.Drawing.Point(49, 580);
            this.IP_Text.Name = "IP_Text";
            this.IP_Text.Size = new System.Drawing.Size(56, 24);
            this.IP_Text.TabIndex = 11;
            this.IP_Text.Text = "[ipv4]";
            this.IP_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Redbox_Logo
            // 
            this.Redbox_Logo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Redbox_Logo.ImageLocation = resources.GetString("Redbox_Logo.ImageLocation");
            this.Redbox_Logo.InitialImage = global::Redbox_Mobile_Command_Center.Properties.Resources.Redbox_Logo;
            this.Redbox_Logo.Location = new System.Drawing.Point(222, 0);
            this.Redbox_Logo.Name = "Redbox_Logo";
            this.Redbox_Logo.Size = new System.Drawing.Size(356, 111);
            this.Redbox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Redbox_Logo.TabIndex = 9;
            this.Redbox_Logo.TabStop = false;
            // 
            // MCC_Title
            // 
            this.MCC_Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MCC_Title.AutoSize = true;
            this.MCC_Title.Font = new System.Drawing.Font("Target Alt Regular", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MCC_Title.Location = new System.Drawing.Point(236, 114);
            this.MCC_Title.Name = "MCC_Title";
            this.MCC_Title.Size = new System.Drawing.Size(329, 35);
            this.MCC_Title.TabIndex = 8;
            this.MCC_Title.Text = "Mobile Command Center";
            this.MCC_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreditText
            // 
            this.CreditText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CreditText.AutoSize = true;
            this.CreditText.Font = new System.Drawing.Font("Target Alt Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditText.Location = new System.Drawing.Point(273, 574);
            this.CreditText.Name = "CreditText";
            this.CreditText.Size = new System.Drawing.Size(255, 24);
            this.CreditText.TabIndex = 14;
            this.CreditText.Text = "created by galacticlemonade";
            this.CreditText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RedboxMobileCommandCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 607);
            this.Controls.Add(this.MainMenuPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RedboxMobileCommandCenter";
            this.Text = "Redbox Mobile Command Center";
            this.MainMenuPanel.ResumeLayout(false);
            this.MainMenuPanel.PerformLayout();
            this.TabletBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RaspberryPI_Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Redbox_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Label CreditText;
        private System.Windows.Forms.GroupBox KioskList;
        private System.Windows.Forms.Label VersionText;
        private System.Windows.Forms.Label IP_Text;
        private System.Windows.Forms.PictureBox RaspberryPI_Logo;
        private System.Windows.Forms.PictureBox Redbox_Logo;
        private System.Windows.Forms.Label MCC_Title;
        private System.Windows.Forms.GroupBox TabletBox;
        private System.Windows.Forms.Button Battery_Btn;
    }
}


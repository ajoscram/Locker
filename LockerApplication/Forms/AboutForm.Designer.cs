namespace Locker
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.developedByLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionNumberLabel = new System.Windows.Forms.Label();
            this.thanksLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.iconLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // developedByLabel
            // 
            this.developedByLabel.AutoSize = true;
            this.developedByLabel.Location = new System.Drawing.Point(21, 25);
            this.developedByLabel.Name = "developedByLabel";
            this.developedByLabel.Size = new System.Drawing.Size(85, 13);
            this.developedByLabel.TabIndex = 0;
            this.developedByLabel.Text = "Developed by:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(124, 25);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(157, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Alejandro Schmidt Ramírez";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(21, 51);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(55, 13);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "Version:";
            // 
            // versionNumberLabel
            // 
            this.versionNumberLabel.AutoSize = true;
            this.versionNumberLabel.Location = new System.Drawing.Point(124, 51);
            this.versionNumberLabel.Name = "versionNumberLabel";
            this.versionNumberLabel.Size = new System.Drawing.Size(25, 13);
            this.versionNumberLabel.TabIndex = 3;
            this.versionNumberLabel.Text = "1.0";
            // 
            // thanksLabel
            // 
            this.thanksLabel.AutoSize = true;
            this.thanksLabel.Location = new System.Drawing.Point(81, 101);
            this.thanksLabel.Name = "thanksLabel";
            this.thanksLabel.Size = new System.Drawing.Size(157, 13);
            this.thanksLabel.TabIndex = 4;
            this.thanksLabel.Text = " Thanks for using locker!";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(12, 131);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(299, 39);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // iconLinkLabel
            // 
            this.iconLinkLabel.AutoSize = true;
            this.iconLinkLabel.Location = new System.Drawing.Point(63, 75);
            this.iconLinkLabel.Name = "iconLinkLabel";
            this.iconLinkLabel.Size = new System.Drawing.Size(199, 13);
            this.iconLinkLabel.TabIndex = 5;
            this.iconLinkLabel.TabStop = true;
            this.iconLinkLabel.Text = "Icon by Chanut from Flaticon.com";
            this.iconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconLinkLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 184);
            this.Controls.Add(this.iconLinkLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.thanksLabel);
            this.Controls.Add(this.versionNumberLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.developedByLabel);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label developedByLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label versionNumberLabel;
        private System.Windows.Forms.Label thanksLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.LinkLabel iconLinkLabel;
    }
}
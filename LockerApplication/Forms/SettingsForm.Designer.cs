namespace Locker
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.minutesNumeric = new System.Windows.Forms.NumericUpDown();
            this.secondsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.clipboardLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.languageCombobox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // minutesNumeric
            // 
            this.minutesNumeric.Location = new System.Drawing.Point(174, 39);
            this.minutesNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.minutesNumeric.Name = "minutesNumeric";
            this.minutesNumeric.Size = new System.Drawing.Size(35, 20);
            this.minutesNumeric.TabIndex = 1;
            // 
            // secondsNumeric
            // 
            this.secondsNumeric.Location = new System.Drawing.Point(234, 39);
            this.secondsNumeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.secondsNumeric.Name = "secondsNumeric";
            this.secondsNumeric.Size = new System.Drawing.Size(33, 20);
            this.secondsNumeric.TabIndex = 2;
            this.secondsNumeric.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = ":";
            // 
            // clipboardLabel
            // 
            this.clipboardLabel.AutoSize = true;
            this.clipboardLabel.Location = new System.Drawing.Point(7, 41);
            this.clipboardLabel.Name = "clipboardLabel";
            this.clipboardLabel.Size = new System.Drawing.Size(115, 13);
            this.clipboardLabel.TabIndex = 5;
            this.clipboardLabel.Text = "Clipboard Timeout:";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(11, 65);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(257, 39);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // languageCombobox
            // 
            this.languageCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCombobox.FormattingEnabled = true;
            this.languageCombobox.Location = new System.Drawing.Point(76, 12);
            this.languageCombobox.Name = "languageCombobox";
            this.languageCombobox.Size = new System.Drawing.Size(193, 21);
            this.languageCombobox.TabIndex = 0;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(9, 15);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(61, 13);
            this.languageLabel.TabIndex = 0;
            this.languageLabel.Text = "Language:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 117);
            this.Controls.Add(this.minutesNumeric);
            this.Controls.Add(this.secondsNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clipboardLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.languageCombobox);
            this.Controls.Add(this.languageLabel);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.ComboBox languageCombobox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label clipboardLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown secondsNumeric;
        private System.Windows.Forms.NumericUpDown minutesNumeric;
    }
}
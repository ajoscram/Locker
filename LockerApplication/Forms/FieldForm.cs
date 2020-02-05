using Locker;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locker
{
    public partial class FieldForm : Form
    {
        private FileForm parent;

        public FieldForm(FileForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(handleKeyDown);
            loadStrings();
        }

        private void loadStrings()
        {
            this.Text = Settings.GetString(this);
            List<Control> controls = new List<Control> { keyLabel, valueLabel, addButton };
            loadStrings(controls);
        }

        private void addField(string key, string value)
        {
            parent.AddFieldToFile(key, value);
            this.Dispose();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try { addField(keyTextbox.Text, valueTextbox.Text); }
            catch (FileException exception) { ShowError(Settings.GetString(exception.Error)); }
        }

        private void handleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;
                this.Dispose();
                Application.Exit();
            }
        }
    }
}

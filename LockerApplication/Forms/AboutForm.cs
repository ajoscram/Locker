using System.Collections.Generic;
using System.Windows.Forms;

namespace LockerUI
{
    public partial class AboutForm : Form
    {
        private FileForm parent;

        public AboutForm(FileForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.KeyDown += new KeyEventHandler(handleKeyDown);
            loadStrings();
        }

        private void loadStrings()
        {
            this.Text = Settings.GetString(this);
            List<Control> controls = new List<Control> { developedByLabel, versionLabel, thanksLabel, closeButton };
            loadStrings(controls);
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
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

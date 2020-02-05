using System.Collections.Generic;
using System.Windows.Forms;

namespace LockerApplication
{
    public partial class HelpForm : Form
    {
        private FileForm parent;

        public HelpForm(FileForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.KeyDown += new KeyEventHandler(handleKeyDown);
            loadStrings();
        }

        public void loadStrings()
        {
            this.Text = Settings.GetString(this);
            List<Control> controls = new List<Control>
            {
                generalTab, generalTextbox, filesTab, filesTextbox,
                encryptersTab, encryptersTextbox, functionalityTab, functionalityTextbox,
                commandLineTab, commandLineTextbox
            };
            loadStrings(controls);
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

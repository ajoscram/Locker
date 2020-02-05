using System.Collections.Generic;
using System.Windows.Forms;

namespace Locker
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const string RESOURCE_PREFIX = "UI_Form_";
        private enum String { UI_Form, LOCKER }

        public Form()
        {
            InitializeComponent();
        }

        protected void loadStrings(List<ToolStripMenuItem> menuItems)
        {
            foreach (ToolStripMenuItem menuItem in menuItems)
                menuItem.Text = Settings.GetString(this, menuItem.Name);
        }

        protected void loadStrings(List<Control> controls)
        {
            foreach (Control control in controls)
                control.Text = Settings.GetString(this, control);
        }

        public void ShowError(string text)
        {
            MessageBox.Show(this, text, Settings.GetString(RESOURCE_PREFIX + String.LOCKER), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInformation(string text)
        {
            MessageBox.Show(this, text, Settings.GetString(RESOURCE_PREFIX + String.LOCKER), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool AskQuestion(string text)
        {
            return MessageBox.Show(this, text, Settings.GetString(RESOURCE_PREFIX + String.LOCKER), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public DialogResult AskCancellableQuestion(string text)
        {
            return MessageBox.Show(this, text, Settings.GetString(RESOURCE_PREFIX + String.LOCKER), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}

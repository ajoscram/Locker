using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locker
{
    public partial class SettingsForm : Form
    {
        private enum String { TIME_EQUALS_ZERO, SETTINGS_SAVED }

        private FileForm parent;

        public SettingsForm(FileForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            foreach (Settings.Language language in Enum.GetValues(typeof(Settings.Language)))
                languageCombobox.Items.Add(language);
            languageCombobox.SelectedItem = Settings.SelectedLanguage;
            minutesNumeric.Value = Settings.ClipboardTimeout / 60; //total number of minutes
            secondsNumeric.Value = Settings.ClipboardTimeout % 60; //60 seconds in a minute
            this.KeyDown += new KeyEventHandler(handleKeyDown);
            loadStrings();
        }

        public void loadStrings()
        {
            this.Text = Settings.GetString(this);
            List<Control> controls = new List<Control> { clipboardLabel, languageLabel, saveButton };
            loadStrings(controls);
        }

        private void save()
        {
            if (minutesNumeric.Value == 0 && secondsNumeric.Value == 0)
                ShowError(Settings.GetString(this, String.TIME_EQUALS_ZERO.ToString()));
            else
            {
                Settings.SelectedLanguage = (Settings.Language)languageCombobox.SelectedItem;
                Settings.ClipboardTimeout = (int)(minutesNumeric.Value * 60 + secondsNumeric.Value);
                Settings.Save();
                ShowInformation(Settings.GetString(this, String.SETTINGS_SAVED.ToString()));
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            save();
            loadStrings();
            parent.loadStrings();
            Dispose();
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

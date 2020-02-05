using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Locker;

namespace Locker
{
    public partial class FileForm : Form
    {
        private enum String
        {
            NEW_FILE, FILE_SAVED, NO_FILE_OPENED, UNSAVED_CHANGES, NO_FIELD_SELECTED,
            OVERWRITE_KEY, DELETE_FIELD 
        }

        private File file_;
        private File file
        {
            get { return file_; }
            set
            {
                file_ = value;
                if (file_ == null)
                {
                    this.Text = Settings.GetString(this);
                    searchTextbox.Enabled = false;
                    searchLabel.Enabled = false;
                    fieldListbox.Visible = false;
                    noFileLabel.Visible = true;
                }
                else
                {
                    if (file_.IsNew())
                        this.Text = Settings.GetString(this, String.NEW_FILE.ToString());
                    else
                        this.Text = file.Path;
                    searchTextbox.Enabled = true;
                    searchLabel.Enabled = true;
                    fieldListbox.Visible = true;
                    noFileLabel.Visible = false;
                }
                updateUI(searchTextbox.Text);
            }
        }

        public FileForm()
        {
            InitializeComponent();
            this.file = null;
            sortAlphabeticallyMenuItem.Checked = Settings.AlphabeticalSorterChecked;
            searchTextbox.TextChanged += searchTextbox_TextChanged;
            loadStrings();
            updateUI();
        }

        #region String Loading and UI Update
        public void loadStrings()
        {
            List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>
            {
                fileMenuItem, openMenuItem, newMenuItem, saveMenuItem,
                closeMenuItem, exitMenuItem, editMenuItem, copySelectedToClipboardMenuItem,
                addNewFieldMenuItem, deleteSelectedMenuItem, settingsMenuItem,
                changeSettingsMenuItem, sortAlphabeticallyMenuItem, helpMenuItem,
                helpMenuItem, viewHelpMenuItem, aboutMenuItem, copyToClipboardMenuItem,
                addMenuItem, deleteMenuItem
            };
            List<Control> controls = new List<Control> { noFileLabel };
            loadStrings(menuItems);
            loadStrings(controls);
        }

        private void updateUI()
        {
            updateUI("");
        }

        private void updateUI(string filter)
        {
            if (file != null)
            {
                if (filter == "")
                {
                    fieldListbox.Items.Clear();
                    foreach (string key in file.Keys)
                        fieldListbox.Items.Add(key);
                }
                else
                {
                    filter = filter.ToLower();
                    fieldListbox.Items.Clear();
                    foreach (string key in file.Keys)
                        if (key.ToLower().Contains(filter))
                            fieldListbox.Items.Add(key);
                }
            }
        }
        #endregion

        #region Functionality
        public void OpenNewFile()
        {
            if (this.file == null)
                this.file = new File();
            else
            {
                ProcessStartInfo info = new ProcessStartInfo(Application.ExecutablePath);
                info.Arguments += CommandLine.UI + " " + CommandLine.NEW_FILE;
                Process.Start(info);
            }
        }

        public void OpenFile(string path, string password, Encrypter encrypter)
        {
            if (this.file == null)
            {
                File file = File.Open(path, password, encrypter);
                this.file = file;
            }
            else
            {
                ProcessStartInfo info = new ProcessStartInfo(Application.ExecutablePath);
                info.Arguments += CommandLine.UI + " " 
                                + CommandLine.FILE + " \"" + path + "\"" + " " 
                                + CommandLine.DECRYPT + " \"" + password + "\" \"" + encrypter.Name + "\"";
                Process.Start(info);
            }
        }

        public void SaveFile(string path, string password, Encrypter encrypter)
        {
            file.Save(path, password, encrypter);
            this.Text = file.Path;
            ShowInformation(Settings.GetString(this, String.FILE_SAVED.ToString()));
        }

        public void CloseFile(bool exitApplicationAfterClosing)
        {
            if (file == null)
                ShowError(Settings.GetString(this, String.NO_FILE_OPENED.ToString()));
            else
            {
                if (file.WasModified())
                {
                    DialogResult result = AskCancellableQuestion(Settings.GetString(this, String.UNSAVED_CHANGES.ToString()));
                    if (result == DialogResult.Yes)
                        new SaveForm(this, file, exitApplicationAfterClosing).ShowDialog();
                    else if (result == DialogResult.Cancel)
                        return;
                }
                file = null;
                if (exitApplicationAfterClosing)
                    Application.Exit();
            }
        }

        public void CopyValueToClipboard(string key)
        {
            if (file == null)
                ShowError(Settings.GetString(this, String.NO_FILE_OPENED.ToString()));
            file.CopyToClipboard(key, Settings.ClipboardTimeout);
        }

        public void CopyValueToClipboard()
        {
            if (fieldListbox.SelectedIndex != -1)
                CopyValueToClipboard((string)fieldListbox.SelectedItem);
            else
                ShowError(Settings.GetString(this, String.NO_FIELD_SELECTED.ToString()));
        }

        public void AddFieldToFile(string key, string value)
        {
            bool fieldExists = file.Keys.Contains(key);
            if (!fieldExists)
            {
                file.Add(key, value);
                updateUI(searchTextbox.Text);
            }
            else if (fieldExists && AskQuestion(Settings.GetString(this, String.OVERWRITE_KEY.ToString())))
            {
                file[key] = value;
                updateUI(searchTextbox.Text);
            }
        }

        public void DeleteFieldFromFile(string key)
        {
            if (file == null)
                ShowError(Settings.GetString(this, String.NO_FILE_OPENED.ToString()));

            if (AskQuestion(Settings.GetString(this, String.DELETE_FIELD.ToString())))
            {
                file.Remove(key);
                updateUI(searchTextbox.Text);
            }
        }

        public void DeleteFieldFromFile()
        {
            if (fieldListbox.SelectedIndex != -1)
                DeleteFieldFromFile((string)fieldListbox.SelectedItem);
            else
                ShowError(Settings.GetString(this, String.NO_FIELD_SELECTED.ToString()));
        }
        #endregion

        #region Search and Sort
        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            updateUI(searchTextbox.Text);
        }

        private void sortAlphabeticallyMenuItem_CheckChanged(object sender, EventArgs e)
        {
            if (sortAlphabeticallyMenuItem.Checked)
                fieldListbox.Sorted = true;
            else
            {
                fieldListbox.Sorted = false;
                updateUI(searchTextbox.Text);
            }
            Settings.AlphabeticalSorterChecked = sortAlphabeticallyMenuItem.Checked;
        }
        #endregion

        #region Form Creation
        private void createOpenForm()
        {
            if (file == null || file.IsNew())
                new OpenForm(this).ShowDialog();
            else
                new OpenForm(this, System.IO.Path.GetDirectoryName(file.Path)).ShowDialog();
        }

        public void CreateOpenForm(string path)
        {
            new OpenForm(this, path).ShowDialog();
        }

        private void createSaveForm()
        {
            if (file == null)
                ShowError(Settings.GetString(this, String.NO_FILE_OPENED.ToString()));
            else
                new SaveForm(this, file, false).ShowDialog();
        }

        private void createFieldForm()
        {
            if (file == null)
                ShowError(Settings.GetString(this, String.NO_FILE_OPENED.ToString()));
            else
                new FieldForm(this).ShowDialog();
        }
        #endregion

        #region General Menu
        private void openMenuItem_Click(object sender, EventArgs e)
        {
            createOpenForm();
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewFile();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            createSaveForm();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile(false);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copySelectedToClipboardMenuItem_Click(object sender, EventArgs e)
        {
            CopyValueToClipboard();
        }

        private void addNewFieldMenuItem_Click(object sender, EventArgs e)
        {
            createFieldForm();
        }

        private void deleteSelectedMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFieldFromFile();
        }

        private void viewHelpMenuItem_Click(object sender, EventArgs e)
        {
            new HelpForm(this).Show();
            Process.Start("https://github.com/ajoscram/Locker/wiki");
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm(this).ShowDialog();
        }

        private void changeSettingsMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm(this).ShowDialog();
        }
        #endregion

        #region Listbox Popup Menu
        private void copyToClipboardMenuItem_Click(object sender, EventArgs e)
        {
            CopyValueToClipboard();
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            createFieldForm();
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFieldFromFile();
        }
        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Settings.Save();
            CloseReason reason = e.CloseReason;
            if (file != null && (reason != CloseReason.TaskManagerClosing || reason != CloseReason.WindowsShutDown))
            {
                CloseFile(true);
                if (reason != CloseReason.ApplicationExitCall)
                    e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
    }
}

using Locker;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locker
{
    public partial class SaveForm : Form
    {
        private FileForm parent;
        private File file;
        bool exitApplicationAfterSaving;

        public SaveForm(FileForm parent, File file, bool exitApplicationAfterSaving)
        {
            InitializeComponent();
            this.exitApplicationAfterSaving = exitApplicationAfterSaving;
            this.parent = parent;
            this.file = file;
            if (!file.IsNew())
            {
                saveFileDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(file.Path);
                saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(file.Path);
            }
            else
                saveFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            foreach (Encrypter encrypter in Encrypter.ENCRYPTERS)
                encryptionComboBox.Items.Add(encrypter);
            encryptionComboBox.SelectedIndex = 0;
            this.KeyDown += new KeyEventHandler(handleKeyDown);
            loadStrings();
        }

        private void loadStrings()
        {
            this.Text = Settings.GetString(this);
            List<Control> controls = new List<Control> { encryptionLabel, passwordLabel, saveButton };
            loadStrings(controls);
        }

        private void saveFile()
        {
            try
            {
                Encrypter encrypter = (Encrypter)encryptionComboBox.SelectedItem;
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;
                    string password = passwordTextbox.Text;
                    parent.SaveFile(path, password, encrypter);
                    this.Close();
                    if (exitApplicationAfterSaving)
                        Application.Exit();
                }
            }
            catch (FileException exception) { ShowError(Settings.GetString(exception.Error)); }
            catch (EncrypterException exception) { ShowError(Settings.GetString(exception.Error)); }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile();
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

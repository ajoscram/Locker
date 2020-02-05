using Locker;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LockerApplication
{
    public partial class OpenForm : Form
    {
        private FileForm parent;
        private string path;

        public OpenForm(FileForm parent, string path)
        {
            InitializeComponent();
            this.parent = parent;
            this.path = path;
            setup();
        }

        public OpenForm(FileForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.path = System.IO.Directory.GetCurrentDirectory();
            setup();
        }

        private void setup()
        {
            foreach (Encrypter encrypter in Encrypter.ENCRYPTERS)
                encryptionComboBox.Items.Add(encrypter);
            encryptionComboBox.SelectedIndex = 0;
            this.KeyDown += new KeyEventHandler(handleKeyDown);
            loadStrings();
        }

        private void loadStrings()
        {
            this.Text = Settings.GetString(this);
            List<Control> controls = new List<Control> { encryptionLabel, openButton, passwordLabel };
            loadStrings(controls);
        }

        private void openFile()
        {
            try
            {
                Encrypter encrypter = (Encrypter)encryptionComboBox.SelectedItem;
                if (System.IO.Directory.Exists(path))
                {
                    DialogResult result = openFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                        parent.OpenFile(openFileDialog.FileName, passwordTextbox.Text, encrypter);
                }
                else //path is file assumed
                    parent.OpenFile(path, passwordTextbox.Text, encrypter);
                this.Close();
            }
            catch (FileException exception) { ShowError(Settings.GetString(exception.Error)); }
            catch (EncrypterException exception) { ShowError(Settings.GetString(exception.Error)); }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFile();
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

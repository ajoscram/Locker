using Locker;
using System;
using System.Windows.Forms;

namespace Locker
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CommandLine cl = new CommandLine(args);
            if (cl.DisplayUI() || cl.ReceivedNoArguments())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FileForm form = new FileForm();

                if (cl.HasErrors())
                    form.ShowError(cl.ErrorMessages);
                else
                {
                    try
                    {
                        //opening a file
                        if (cl.HasFile() && cl.HasDecryptInfo())
                            form.OpenFile(cl.File, cl.Password, cl.Encrypter);
                        else if (cl.HasFile())
                            form.CreateOpenForm(cl.File);
                        else if (cl.CreateNewFile())
                            form.OpenNewFile();
                        //fetching a field
                        if (cl.HasField())
                            form.CopyValueToClipboard(cl.Field);
                    }
                    catch (FileException e) { form.ShowError(Settings.GetString(e.Error)); }
                    catch (EncrypterException e) { form.ShowError(Settings.GetString(e.Error)); }
                }
                Application.Run(form);
            }
            else if (cl.HasFile() && cl.HasDecryptInfo())
            {
                if (cl.HasErrors())
                    Clipboard.SetText(cl.ErrorMessages);
                else
                {
                    try
                    {
                        File file = File.Open(cl.File, cl.Password, cl.Encrypter);
                        if (cl.HasField())
                            file.CopyToClipboard(cl.Field, Settings.ClipboardTimeout);
                    }
                    catch (FileException e) { Clipboard.SetText(Settings.GetString(e.Error)); }
                    catch (EncrypterException e) { Clipboard.SetText(Settings.GetString(e.Error)); }
                }
            }
        }
    }
}

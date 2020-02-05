using System.Globalization;
using System.Reflection;
using System.Resources;
using Locker;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace LockerApplication
{
    public static class Settings
    {
        //the individual values on this enum correspond to the int value of the cultureinfo ID
        public enum Language { English = 9, Español = 10 }
        private enum Prefix { UI, FILE_ERROR, ENCRYPTER_ERROR, COMMAND_LINE_ERROR }

        private static ResourceManager resourceManager;

        static Settings()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            string resourcePath = assembly.GetName().Name + ".Resources.Strings";
            resourceManager = new ResourceManager(resourcePath, assembly);
            CultureInfo.CurrentUICulture = new CultureInfo((int)SelectedLanguage);
        }

        public static Language SelectedLanguage
        {
            get { return (Language)Properties.Settings.Default.Language; }
            set
            {
                Properties.Settings.Default.Language = (int)value;
                CultureInfo.CurrentUICulture = new CultureInfo((int)value);
            }
        }

        //this is in seconds
        public static int  ClipboardTimeout
        {
            get { return Properties.Settings.Default.ClipboardTimeout; }
            set { Properties.Settings.Default.ClipboardTimeout = value; }
        }

        public static bool AlphabeticalSorterChecked
        {
            get { return Properties.Settings.Default.AlphabeticalSorterChecked; }
            set { Properties.Settings.Default.AlphabeticalSorterChecked = value; }
        }

        public static void Save()
        {
            Properties.Settings.Default.Save();
        }

        public static string GetString(File.Error error)
        {
            return resourceManager.GetString(Prefix.FILE_ERROR + "_" + error, CultureInfo.CurrentUICulture);
        }

        public static string GetString(Encrypter.Error error)
        {
            return resourceManager.GetString(Prefix.ENCRYPTER_ERROR + "_" + error, CultureInfo.CurrentUICulture);
        }

        public static string GetString(CommandLine.Error error)
        {
            return resourceManager.GetString(Prefix.COMMAND_LINE_ERROR + "_" + error, CultureInfo.CurrentUICulture);
        }

        public static string GetString(Form form)
        {
            return resourceManager.GetString(Prefix.UI + "_" + form.Name, CultureInfo.CurrentUICulture);
        }

        public static string GetString(string identifier)
        {
            return resourceManager.GetString(identifier, CultureInfo.CurrentUICulture);
        }

        public static string GetString(Form form, string identifier)
        {
            return resourceManager.GetString(Prefix.UI + "_" + form.Name + "_" + identifier, CultureInfo.CurrentUICulture);
        }

        public static string GetString(Form form, Control control)
        {
            return resourceManager.GetString(Prefix.UI + "_" + form.Name + "_" + control.Name, CultureInfo.CurrentUICulture);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Locker
{
    public class File
    {
        public enum Error
        {
            //CRUD
            EMPTY_KEY, MISSING_KEY, EMPTY_VALUE, KEY_CONTAINS_PROPERTY_SEPARATOR, KEY_CONTAINS_FIELD_SEPARATOR, VALUE_CONTAINS_FIELD_SEPARATOR, FIELD_DOES_NOT_CONTAIN_SEPARATOR,
            //IO
            CHECKS_DID_NOT_MATCH, NON_VALID_PATH, PATH_TOO_LONG, DIRECTORY_NOT_FOUND, IO_ERROR, UNAUTHORIZED_ACCESS, FILE_NOT_FOUND
        }

        private const int MINIMUM_CHECK_SIZE = 50;
        private const int MAXIMUM_CHECK_SIZE = 100;

        public const char PROPERTY_SEPARATOR = '\t';
        public const char FIELD_SEPARATOR = '\n';

        private bool modified; //determines if a file object was changed since its creation or last save 
        private Dictionary<string, string> fields { get; set; }
        public int Count { get { return fields.Count; } }
        public List<string> Keys { get { return fields.Keys.ToList(); } }
        public string Path { get; private set; }

        public File()
        {
            this.fields = new Dictionary<string, string>();
            this.Path = "";
            this.modified = false;
        }

        #region CRUD Operations
        public void Add(string key, string value)
        {
            if (key == "")
                throw new FileException(Error.EMPTY_KEY, this, this.Count);
            else if (value == "")
                throw new FileException(Error.EMPTY_VALUE, this, this.Count);
            else if (key.Contains(PROPERTY_SEPARATOR))
                throw new FileException(Error.KEY_CONTAINS_PROPERTY_SEPARATOR, this, this.Count);
            else if (key.Contains(FIELD_SEPARATOR))
                throw new FileException(Error.KEY_CONTAINS_FIELD_SEPARATOR, this, this.Count);
            else if (value.Contains(FIELD_SEPARATOR))
                throw new FileException(Error.VALUE_CONTAINS_FIELD_SEPARATOR, this, this.Count);
            else
            {
                fields.Add(key, value);
                modified = true;
            }
        }

        public void Add(string field)
        {
            if (field.Contains(PROPERTY_SEPARATOR))
            {
                char[] separatorArray = { PROPERTY_SEPARATOR };
                string[] parts = field.Split(separatorArray, 2);
                string key = parts[0];
                string value = parts[1];
                Add(key, value);
            }
            else
                throw new FileException(Error.FIELD_DOES_NOT_CONTAIN_SEPARATOR, this, this.Count);
        }

        public void Remove(string key)
        {
            bool removed = fields.Remove(key);
            if(removed)
                modified = true;
        }

        public string this[string key]
        {
            get
            {
                if (fields.ContainsKey(key))
                    return fields[key];
                else
                    throw new FileException(Error.MISSING_KEY, this);
            }
            set
            {
                if (fields.ContainsKey(key))
                {
                    fields[key] = value;
                    modified = true;
                }
                else
                    throw new FileException(Error.MISSING_KEY, this);
            }
        }
        #endregion

        #region IO Operations
        public static File Open(string path, string password, Encrypter encrypter)
        {
            try
            {
                string decrypted = encrypter.Decrypt(System.IO.File.ReadAllText(path), password);
                List<string> fields = decrypted.Split(FIELD_SEPARATOR).ToList();
                if (fields.Count >= 2 && fields[0] == fields[fields.Count - 1])
                {
                    fields.RemoveAt(0);
                    fields.RemoveAt(fields.Count - 1);
                    File file = new File();
                    file.Path = path;
                    foreach (string field in fields)
                        file.Add(field);
                    file.modified = false;
                    return file;
                }
                else
                    throw new FileException(Error.CHECKS_DID_NOT_MATCH);
            }
            catch (ArgumentException) { throw new FileException(Error.NON_VALID_PATH); }
            catch (PathTooLongException) { throw new FileException(Error.PATH_TOO_LONG); }
            catch (DirectoryNotFoundException) { throw new FileException(Error.DIRECTORY_NOT_FOUND); }
            catch (UnauthorizedAccessException) { throw new FileException(Error.UNAUTHORIZED_ACCESS); }
            catch (FileNotFoundException) { throw new FileException(Error.FILE_NOT_FOUND); }
            catch (IOException) { throw new FileException(Error.IO_ERROR); }
            catch (NotSupportedException) { throw new FileException(Error.NON_VALID_PATH); }
            catch (SecurityException) { throw new FileException(Error.UNAUTHORIZED_ACCESS); }
        }

        private string generateCheck()
        {
            byte[] byteKey = new byte[new Random().Next(MINIMUM_CHECK_SIZE, MAXIMUM_CHECK_SIZE)];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            string key;
            do
            {
                rng.GetNonZeroBytes(byteKey);
                //the encoding doesn't really matter, as long as its 1 byte per character.
                key = Encoding.ASCII.GetString(byteKey);
            }
            while (key.Contains(FIELD_SEPARATOR));
            return key;
        }

        public void Save(string path, string password, Encrypter encrypter)
        {
            try
            {
                string check = generateCheck();
                string text = encrypter.Encrypt(check + FIELD_SEPARATOR + this.ToString() + FIELD_SEPARATOR + check, password);
                System.IO.File.WriteAllText(path, text);
                this.Path = path;
                this.modified = false;
            }
            catch (ArgumentException) { throw new FileException(Error.NON_VALID_PATH); }
            catch (PathTooLongException) { throw new FileException(Error.PATH_TOO_LONG); }
            catch (DirectoryNotFoundException) { throw new FileException(Error.DIRECTORY_NOT_FOUND); }
            catch (UnauthorizedAccessException) { throw new FileException(Error.UNAUTHORIZED_ACCESS); }
            catch (FileNotFoundException) { throw new FileException(Error.FILE_NOT_FOUND); }
            catch (IOException) { throw new FileException(Error.IO_ERROR); }
            catch (NotSupportedException) { throw new FileException(Error.NON_VALID_PATH); }
            catch (SecurityException) { throw new FileException(Error.UNAUTHORIZED_ACCESS); }
        }
        #endregion

        #region Clipboard Support
        private volatile bool clipboardTimerStarted = false;
        private volatile int clipboardTimer = 0;

        private void clearClipboard(int seconds)
        {
            clipboardTimer = seconds;
            if (!clipboardTimerStarted)
            {
                clipboardTimerStarted = true;
                while (clipboardTimer > 0)
                {
                    Thread.Sleep(1000); // wait for one second
                    clipboardTimer--;
                }
                Clipboard.SetText(" ");
                clipboardTimerStarted = false;
            }

        }

        public void CopyToClipboard(string key)
        {
            string password = this[key];
            if (password == null)
                throw new FileException(Error.MISSING_KEY, this);
            Clipboard.SetText(password);
        }

        public void CopyToClipboard(string key, int seconds)
        {
            CopyToClipboard(key);
            Thread thread = new Thread(() => clearClipboard(seconds));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        #endregion

        public bool WasModified()
        {
            return modified;
        }

        public bool IsNew()
        {
            return Path == "";
        }

        public override string ToString()
        {
            string str = "", last = fields.Last().Key;
            foreach (string key in fields.Keys)
            {
                str += key + PROPERTY_SEPARATOR + fields[key];
                if (key != last)
                    str += FIELD_SEPARATOR;
            }
            return str;
        }
    }

    public class FileException : Exception
    {
        private const int NO_LINE = -1;

        public File.Error Error { get; }
        public new File Source { get; }
        public int Line { get; }

        public FileException(File.Error error) : base(error + " thrown.")
        {
            this.Error = error;
            this.Source = null;
            this.Line = NO_LINE;
        }

        public FileException(File.Error error, File source) : base(error + " thrown.\nPath: " + source.Path)
        {
            this.Error = error;
            this.Source = source;
            this.Line = NO_LINE;
        }

        public FileException(File.Error error, File source, int line) : base(error + " thrown.\nPath: " + source.Path + "\nLine: " + line)
        {
            this.Error = error;
            this.Source = source;
            this.Line = line;
        }
    }
}

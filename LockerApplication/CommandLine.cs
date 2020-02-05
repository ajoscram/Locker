using System;
using System.Collections.Generic;
using System.Linq;
using Locker;

namespace Locker
{
    public sealed class CommandLine
    {
        public enum Error
        {
            EXPECTED_FLAG, EXPECTED_ARGUMENT, EXPECTED_FILEPATH, EXPECTED_FIELD,
            EXPECTED_PASSWORD, EXPECTED_ENCRYPTER, MESSAGE
        }

        public const string FILE = "-file";
        public const string DECRYPT = "-decrypt";
        public const string FIELD = "-field";
        public const string UI = "-ui";
        public const string NEW_FILE = "-new";

        private bool has0Arguments;
        private List<CommandLineException> Exceptions;
        private bool Ui { get; }
        private bool NewFile { get; }
        public string File { get; }
        public string Password { get; }
        public Encrypter Encrypter { get; }
        public string Field { get; }

        public string ErrorMessages
        {
            get
            {
                if (this.HasErrors())
                {
                    string message = Settings.GetString(Error.MESSAGE);
                    foreach (CommandLineException ex in Exceptions)
                        message += "\n - " + ex.Message;
                    return message;
                }
                else
                    return "";
            }
        }

        public CommandLine(string[] arguments)
        {
            has0Arguments = arguments.Count() == 0;
            Exceptions = new List<CommandLineException>();
            File = null;
            Password = null;
            Field = null;
            Ui = false;
            NewFile = false;
            try
            {
                for (int i = 0; i < arguments.Count(); i++)
                {
                    switch (arguments[i].ToLower())
                    {
                        case UI:
                            Ui = true;
                            break;
                        case NEW_FILE:
                            NewFile = true;
                            break;
                        case FILE:
                            if (!isFlag(arguments[i + 1]))
                                File = arguments[++i];
                            else
                                Exceptions.Add(new CommandLineException(Error.EXPECTED_FILEPATH, arguments[i + 1]));
                            break;
                        case FIELD:
                            if (!isFlag(arguments[i + 1]))
                                Field = arguments[++i];
                            else
                                Exceptions.Add(new CommandLineException(Error.EXPECTED_FIELD, arguments[i + 1]));
                            break;
                        case DECRYPT:
                            if (!isFlag(arguments[i + 1]))
                                Password = arguments[++i];
                            else
                                Exceptions.Add(new CommandLineException(Error.EXPECTED_PASSWORD, arguments[i + 1]));
                            if (!isFlag(arguments[i + 1]))
                                Encrypter = getEncrypter(arguments[++i]);
                            else
                                Exceptions.Add(new CommandLineException(Error.EXPECTED_ENCRYPTER, arguments[i + 1]));
                            break;
                        default:
                            Exceptions.Add(new CommandLineException(Error.EXPECTED_FLAG, arguments[i]));
                            break;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Exceptions.Add(new CommandLineException(Error.EXPECTED_ARGUMENT, arguments[arguments.Count() - 1]));
            }
        }

        private Encrypter getEncrypter(string name)
        {
            foreach (Encrypter encrypter in Encrypter.ENCRYPTERS)
                if (encrypter.Name.ToLower() == name.ToLower())
                    return encrypter;
            return null;
        }

        private bool isFlag(string str)
        {
            return str == FILE || str == DECRYPT || str == FIELD || str == UI;
        }

        public bool HasFile() { return File != null; }
        public bool HasDecryptInfo() { return Password != null && Encrypter != null; }
        public bool HasField() { return Field != null; }
        public bool HasErrors() { return Exceptions.Count != 0; }
        public bool DisplayUI() { return Ui; }
        public bool CreateNewFile() { return NewFile; }
        public bool ReceivedNoArguments() { return has0Arguments; }

        public override string ToString()
        {
            if (has0Arguments)
                return "No Arguments.";
            else
            {
                string str = "";

                if (File == null)
                    str += "File: null\n";
                else
                    str += "File: " + File + "\n";

                if (Password == null)
                    str += "Password: null\n";
                else
                    str += "Password: " + Password + "\n";

                if (Encrypter == null)
                    str += "Encrypter: null\n";
                else
                    str += "Encrypter: " + Encrypter + "\n";

                if (Field == null)
                    str += "Field: null\n";
                else
                    str += "Field: " + Field + "\n";

                str += "Show UI: " + Ui + "\n";
                str += "Create a New File: " + Ui + "\n";

                str += ErrorMessages;
                return str;
            }
        }
    }

    public sealed class CommandLineException : Exception
    {
        public CommandLine.Error Error { get; }
        public new string Source { get; }
        public new string Message
        {
            get { return Settings.GetString(Error) + " ( " + Source + " )"; }
        }

        public CommandLineException(CommandLine.Error error, string source)
        {
            this.Error = error;
            this.Source = source;
        }
    }
}

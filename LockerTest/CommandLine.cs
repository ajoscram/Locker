using System;
using System.Collections.Generic;
using System.Linq;
using Locker;

namespace LockerTest
{
    public sealed class CommandLine
    {
        public const string FILE = "-file";
        public const string DECRYPT = "-decrypt";
        public const string FIELD = "-field";
        public const string UI = "-ui";

        private bool has0Arguments;
        private List<string> Errors;
        public string File { get; }
        public string Password { get; }
        public Encrypter Encrypter { get; }
        public string Field { get; }
        public bool Ui { get; }

        public override string ToString()
        {
            if (has0Arguments)
                return "No Arguments.";
            else
            {
                string str = "File: " + File + "\n";
                str += "Password: " + Password + "\n";
                if (Encrypter == null)
                    str += "Encrypter: null\n";
                else
                    str += "Encrypter: " + Encrypter + "\n";
                str += "Field: " + Field + "\n";
                str += "Show UI: " + Ui + "\n";
                str += ErrorMessages;
                return str;
            }
        }

        public string ErrorMessages
        {
            get
            {
                if (this.HasErrors())
                {
                    string message = "Errors:";
                    foreach (string error in Errors)
                        message += "\n - " + error;
                    return message;
                }
                else
                    return "";
            }
        }

        public CommandLine(string[] arguments)
        {
            has0Arguments = arguments.Count() == 0;
            Errors = new List<string>();
            File = "";
            Password = "";
            Field = "";
            Ui = false;
            try
            {
                for (int i = 0; i < arguments.Count(); i++)
                {
                    switch (arguments[i].ToLower())
                    {
                        case UI:
                            Ui = true;
                            break;
                        case FILE:
                            if (!isFlag(arguments[i + 1]))
                                File = arguments[++i];
                            else
                                Errors.Add("wrong file argument: " + arguments[i + 1]);
                            break;
                        case FIELD:
                            if (!isFlag(arguments[i + 1]))
                                Field = arguments[++i];
                            else
                                Errors.Add("wrong field argument: " + arguments[i + 1]);
                            break;
                        case DECRYPT:
                            if (!isFlag(arguments[i + 1]))
                                Password = arguments[++i];
                            else
                                Errors.Add("wrong password argument: " + arguments[i + 1]);
                            if (!isFlag(arguments[i + 1]))
                                Encrypter = getEncrypter(arguments[++i]);
                            else
                                Errors.Add("wrong encrypter argument: " + arguments[i + 1]);
                            break;
                        default:
                            Errors.Add("Expected a flag, got:" + arguments[i]);
                            break;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Errors.Add("Expected an argument, got: " + arguments[arguments.Count() - 1]);
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

        public bool HasFile() { return File != ""; }
        public bool HasDecryptInfo() { return Password != "" && Encrypter != null; }
        public bool HasField() { return Field != ""; }
        public bool HasErrors() { return Errors.Count != 0; }
        public bool DisplayUI() { return Ui; }
        public bool ReceivedNoArguments() { return has0Arguments; }
    }
}

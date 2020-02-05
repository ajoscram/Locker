using System;
using System.Collections.Generic;
using System.Linq;

namespace Locker
{
    public abstract class Encrypter
    {
        public enum Error { EMPTY_MESSAGE, EMPTY_PASSWORD }

        public static List<Encrypter> ENCRYPTERS;

        static Encrypter()
        {
            ENCRYPTERS = new List<Encrypter>();
            List<Type> types = typeof(Encrypter).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Encrypter))).ToList();
            foreach (Type type in types)
                ENCRYPTERS.Add((Encrypter)Activator.CreateInstance(type));
        }

        public abstract string Name { get; }
        public abstract string Encrypt(string message, string password);
        public abstract string Decrypt(string message, string password);

        protected void validate(string message, string password)
        {
            validateMessage(message);
            validatePassword(password);
        }

        protected virtual void validateMessage(string message)
        {
            if (message == "")
                throw new EncrypterException(Error.EMPTY_MESSAGE, message);
        }

        protected virtual void validatePassword(string password)
        {
            if (password == "")
                throw new EncrypterException(Error.EMPTY_PASSWORD, password);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class NoEncrypter : Encrypter
    {
        public override string Name { get { return "None"; } }

        public override string Encrypt(string message, string password)
        {
            return message;
        }

        public override string Decrypt(string message, string password)
        {
            return message;
        }
    }

    public class XOREncrypter : Encrypter
    {
        public override string Name { get { return "XOR"; } }

        public override string Encrypt(string message, string password)
        {
            validate(message, password);
            char[] chars = message.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                chars[i] ^= password[i % password.Length];
            return new string(chars);
        }

        public override string Decrypt(string message, string password)
        {
            return Encrypt(message, password);
        }
    }

    public class EncrypterException : Exception
    {
        public Encrypter.Error Error { get; }
        public new string Source { get; }

        public EncrypterException(Encrypter.Error error, string source)
        {
            this.Error = error;
            this.Source = source;
        }
    }
}

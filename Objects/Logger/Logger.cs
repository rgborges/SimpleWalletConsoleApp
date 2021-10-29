using System;
using System.IO;

namespace SimpleWalletConsoleApp.Objects.Logger
{
    public partial class Logger
    {
        private string path;
        public string Path { get => path; private set => path = value; }
        public Logger(string path)
        {
            if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
            {
                this.Path = path;
            }
            try
            {
                if(!File.Exists(Path))
                {
                    using (StreamWriter sw = File.CreateText(Path))
                    {
                        sw.WriteLine($"Starting log at {0}", DateTime.Today.ToString());
                    }
                }
            }
            catch
            {
                throw new FileLoadException("File not found");
            }

        }
        public void Append(string message)
        {
            try
            {
                if(File.Exists(Path))
                {
                    using (StreamWriter sw = File.AppendText(Path))
                    {
                        sw.WriteLine(message);
                    }
                }
            }
            catch
            {
                throw new FileLoadException("File not found");
            }
        }

    }
}
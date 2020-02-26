using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeegaFleeexTool
{
    public class CredentialsGetter
    {
        private string user;
        private string pwd;

        public const string FILE_NAME = "Config.txt";
        public const string KEY = "Spizzi";

        public CredentialsGetter()
        {
            LoadOrRequestCredentials();
        }

        private void LoadOrRequestCredentials()
        {
            if (File.Exists(FILE_NAME))
            {
                List<string> lines = File.ReadLines(FILE_NAME).ToList<string>();
                if (lines.Count != 2)
                    return;

                user = lines[0];
                pwd = lines[1];
            }
        }

        public bool HasValidCredentials()
        {
            return user != null && pwd != null;
        }

        private bool IsFileValid()
        {
            if (!File.Exists(FILE_NAME))
                return false;


            return File.Exists(FILE_NAME);
        }

        public string GetUser()
        {
            return user;
        }

        public string GetPassword()
        {
            return Crypt.Decrypt(pwd, KEY);
        }
    }
}

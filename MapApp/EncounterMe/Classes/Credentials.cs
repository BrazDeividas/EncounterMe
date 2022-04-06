using System;
using System.Collections.Generic;
using System.Text;

namespace EncounterMe
{
    public class Credentials
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Credentials(string name, string password)
        {
            Name = name;
            Password = password;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InstaPyGUI.Model
{
    public class login
    {
        public string title_login { get; }
        public string title_password { get; }
        public bool savedata { get; }

        public login(string _title_login, string _title_password, bool _savedata)
        {
            title_login = _title_login;
            title_password = _title_password;
            savedata = _savedata;
        }
    }
}

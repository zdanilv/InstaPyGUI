using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace InstaPyGUI.ViewModel
{
    public class ViewModel
    {
        private string title_login, title_password;
        private bool savedata;

        public ViewModel()
        {
            Title_Login = "Логин";
            Title_Password = "Пароль";
            SaveData = true;
        }

        public string Title_Login
        {
            get { return title_login; }

            set
            {
                title_login = value;
                OnPropertyChanged("Title_Login");
            }
        }

        public string Title_Password
        {
            get { return title_password; }

            set
            {
                title_password = value;
                OnPropertyChanged("Title_Password");
            }
        }

        public bool SaveData
        {
            get { return savedata; }

            set
            {
                savedata = value;
                OnPropertyChanged("SaveData");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

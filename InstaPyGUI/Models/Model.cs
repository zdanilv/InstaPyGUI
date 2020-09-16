using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace InstaPyGUI.Model
{
    public class Model
    {
        private string _login;
        private string _password;
        private bool _savelogindetails;

        public string InfoLogin
        {
            get
            {
                return _login;
            }
        }
        public string InfoPassword
        {
            get
            {
                return _password;
            }
        }
        public bool InfoSaveLoginDetails
        {
            get
            {
                Console.WriteLine("Вывод2: " + _savelogindetails);
                return _savelogindetails;
            }
        }

        public Model()
        {
            _login = GetLogin();
            _password = GetPassword();
            _savelogindetails = GetSaveLoginDetails();
        }

        private string GetLogin()
        {
            return "admin";
        }
        private string GetPassword()
        {
            return "password";
        }
        private bool GetSaveLoginDetails()
        {
            Console.WriteLine("Вывод1: " + _savelogindetails);
            return true;
        }
    }
}

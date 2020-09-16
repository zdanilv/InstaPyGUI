using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InstaPyGUI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _password;
        private bool _savelogindetails;

        private Model.Model model = new Model.Model();
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool SaveLoginDetails
        {
            get { return _savelogindetails; }
            set
            {
                _savelogindetails = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            _login = model.InfoLogin;
            _password = model.InfoPassword;
            //_savelogindetails = model.InfoSaveLoginDetails;
            SignInCommand = new Command(DoSignInCommand);
        }

        public ICommand SignInCommand { get; private set; }
        private void DoSignInCommand()
        {
            _savelogindetails = model.InfoSaveLoginDetails;
            OnPropertyChanged();
            Console.WriteLine("Вывод: " + _savelogindetails);
        }
    }
}

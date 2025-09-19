using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task2_10_1.Models;

namespace Task2_10_1.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _username;
        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }


        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _statusMessage = "Введите учетные данные";
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }
        private bool _isSuccess;

        public bool IsSuccess
        {
            get => _isSuccess;

            set
            {
                _isSuccess = value;
                OnPropertyChanged();
            }

        }

        public ICommand LoginCommand { get; }
        private void OnLoginCommandExecute(object? parameter)
        {
            bool success = AuthModel.Authenticate(UserName, Password);
            IsSuccess = success;
            StatusMessage = success ? "Успешный вход! Добро пожаловать!" : "Ошибка: неверные данные";
        }


        private bool CanLoginCommandExecute(object? parameter) => !string.IsNullOrEmpty(UserName) || !string.IsNullOrEmpty(Password);

        public MainWindowViewModel()
        {
            LoginCommand = new RelayCommand(OnLoginCommandExecute, CanLoginCommandExecute);
        }


    }
}

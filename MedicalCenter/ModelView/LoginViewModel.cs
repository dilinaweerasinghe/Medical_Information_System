using MedicalCenter.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCenter.ModelView
{
    public class LoginViewModel : LoginModelBase
    {
        private string _username;
        private string _password;
        private string _loginType = "Administrator";
        private string _errorMessage;
        private bool _isViewVisible = true;
        private ObservableCollection<User> _users;
        private User targetUser;


        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password 
        { 
            get
            {
                return _password;
            }

            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string LoginType
        {
            get
            {
                return _loginType;
            }

            set
            {
                _loginType = value;
                OnPropertyChanged(nameof(LoginType));
            }
        }

        public string ErrorMessage
        {
            get
            {
                    return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }

            set
            {
                _users = value;
            }
        }

        public ICommand LoginbtCommand { get;}
        public User TargetUser {
            get 
            {
                return targetUser;            
            }

            set
            {
                targetUser = value;
                OnPropertyChanged(nameof(TargetUser));
            } 
        }

        public LoginViewModel()
        {
            LoginbtCommand = new LoginCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            Users = new ObservableCollection<User>();
           
        }


        private bool CanExecuteLoginCommand(object obj)
        {
            return true;

        }

        private void ExecuteLoginCommand(object obj)
        {
           if(string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Username & Password fields cannot be empty or whitespace!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                LoginValidation validation = new LoginValidation();
                if(validation.UsernameValidate(Username))
                {
                    if(Password == validation.PasswordValidate(Username)) 
                    {
                        MessageBox.Show("Login Successful!", "Login Sucessful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Password is incorrect. Please try again! ", "Login Unsucessful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Username is not exist. Please try again! ", "Login Unsucessful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
            }
        }
    }

    
}

using CarsDeal.Data.Context;
using CarsDeal.Data.Core;
using CarsDeal.Data.Models;
using Microsoft.Identity.Client;
using ProductsIs31.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarsDeal.Data.ViewModel
{
    internal class PageRegistrationViewModel : INotifyPropertyChanged
    {
        private string _login;
        public string Login
        {
            get => _login; 
            set 
            {
                _login = value;
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

        private int _userTypeId;
        public int UserTypeId
        {
            get => _userTypeId;
            set
            {
                _userTypeId = value;
                OnPropertyChanged();
            }
        }
       
        public IEnumerable<UserType> UserTypes => ConnectToDb.db.UserTypes.ToList();

        private RelayCommand addUser;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string value = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(value));
        }

        public RelayCommand AddUser
        {
            get
            {
                return addUser ?? (new RelayCommand(obj =>
                {
                        User user = new User
                        {
                            Login = _login,
                            Password = _password,
                            UserTypeId = _userTypeId
                        };
                        ConnectToDb.db.Users.Add(user);
                        ConnectToDb.db.SaveChanges();
                }));
            }
        }
    }
}

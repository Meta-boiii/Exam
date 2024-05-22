using CarsDeal.Data.Context;
using CarsDeal.Data.Core;
using CarsDeal.Data.Models;
using CarsDeal.Pages;
using Microsoft.EntityFrameworkCore;
using ProductsIs31.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDeal.Data.ViewModel
{
    internal class PageLoginViewModel
    {
        public string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;

            }
        }

        public string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }
        
        private RelayCommand loginUser;

        public RelayCommand LoginUser
        {
            get
            {
                return loginUser ?? (new RelayCommand(obj =>
                {
                        if (ConnectToDb.db.Users.Any(u=>u.Login == _login) && ConnectToDb.db.Users.Any(u => u.Password == _password))
                        {
                            User user = ConnectToDb.db.Users.First(e => e.Login == _login);
                            switch (user.UserTypeId)
                            {
                                case 1:
                                    
                                    SuppObj.mainFrame.Navigate(new PageAdmin());
                                    break;
                                case 2:
                                    
                                    SuppObj.mainFrame.Navigate(new PageOperator());
                                    break;
                                case 3:
                                    SuppObj.mainFrame.Navigate(new PageVendor());
                                    break;
                            }
                        }
                }));
            }
        }
    }
}

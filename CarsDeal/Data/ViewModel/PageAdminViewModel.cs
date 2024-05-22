using CarsDeal.Data.Context;
using CarsDeal.Data.Core;
using CarsDeal.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProductsIs31.Data;
using Microsoft.EntityFrameworkCore;

namespace CarsDeal.Data.ViewModel 
{
    class PageAdminViewModel : INotifyPropertyChanged
    {
        
        private List<Order> orders = ConnectToDb.db.Orders.ToList();
        public List<Order> Orders
        {
            get => orders;
            set {
                orders = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<OrderStatus> OrderStatuses => ConnectToDb.db.OrderStatuses.ToList();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand edit;
        public RelayCommand Edit
        {
            get
            {
                return edit ?? (new RelayCommand(obj =>
                {
                            ConnectToDb.db.SaveChanges();
                }));
            }
        }

        public RelayCommand delete;
        public RelayCommand Delete
        {
            get
            {
                return delete ?? (new RelayCommand(obj =>
                {
                            Order order = ConnectToDb.db.Orders.Find(int.Parse(obj.ToString()));
                            ConnectToDb.db.Orders.Remove(order);
                            ConnectToDb.db.SaveChanges();
                            Orders = ConnectToDb.db.Orders.ToList();
                }));
            }
        }        
        
    }   
}

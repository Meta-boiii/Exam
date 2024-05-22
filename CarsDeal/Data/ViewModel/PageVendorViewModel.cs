using CarsDeal.Data.Context;
using CarsDeal.Data.Core;
using CarsDeal.Data.Models;
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
    internal class PageVendorViewModel 
    {
        private List<Order> orders = ConnectToDb.db.Orders.ToList();
        public List<Order> Orders
        {
            get => orders;
            set => orders = value;
        }
        public IEnumerable<OrderStatus> OrderStatuses  => ConnectToDb.db.OrderStatuses.ToList();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand save;
        public RelayCommand Save
        {
            get
            {
                return save ?? (new RelayCommand(obj =>
                {
                            ConnectToDb.db.SaveChanges();
                }));
            }
        }
    }
}

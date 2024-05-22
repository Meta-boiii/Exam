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
    internal class PageOperatorViewModel : INotifyPropertyChanged
    {
        private string _nameOrder;
        public string NameOrder
        {
            get => _nameOrder;
            set
            {
                _nameOrder = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _orderStatusId;
        public string OrderStatusId
        {
            get => _orderStatusId;
            set
            {
                _orderStatusId = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<OrderStatus> OrderStatuses => ConnectToDb.db.OrderStatuses.ToList();
        
        public RelayCommand addOrder;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string value = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(value));
        }
        
        public RelayCommand AddOrder
        {
            get
            {
                return addOrder ?? (new RelayCommand(obj =>
                {
                        Order order = new Order
                        {
                            NameOrder = _nameOrder,
                            Description = _description,
                            OrderStatusId = _orderStatusId
                        };
                            ConnectToDb.db.Orders.Add(order);
                            ConnectToDb.db.SaveChanges();
                }));
            }
        }
    }
}

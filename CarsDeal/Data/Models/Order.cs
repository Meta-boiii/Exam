using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDeal.Data.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public string NameOrder { get; set; }
        public string Description {  get; set; }
        public string OrderStatusId { get; set; }

        public List<OrderStatus> orderStatuses { get; set; } = new List<OrderStatus>();
    }
}

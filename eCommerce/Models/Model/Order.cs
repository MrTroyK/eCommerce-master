using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public ShoppingCart Basket { get; set; }
        public User Client { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public Status Status { get; set; }
        public bool Payment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public User Buyer { get; set; }
        public ICollection<Article> Articles { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

using System;
namespace Model.Model
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Article Article { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        }
}

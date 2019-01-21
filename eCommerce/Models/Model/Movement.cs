using System;
namespace Model.Model
{
    public class Movement
    {
        public Guid Id { get; set; }
        public Article Article { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}

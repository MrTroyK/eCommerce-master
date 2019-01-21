using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class Tax
    {
        public Guid Id { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Model
{
    public class Address
    {
        public Guid Id { get; set; }
        [ForeignKey("UserForeignKey")]
        public User User { get; set; }

        [Required]
        public int? Number { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        public string Country { get; set; }
    }
}

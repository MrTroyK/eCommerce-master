using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class Comment
    {
        public Guid Id { get; set;}
        public User User { get; set; }
        public Article Article { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime SeenAt { get; set; }

    }
}

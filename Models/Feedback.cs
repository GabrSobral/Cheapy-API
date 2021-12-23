using System;

namespace Cheapy_API.Models
{
    public class Feedback
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Stars { get; set; }
    }
}
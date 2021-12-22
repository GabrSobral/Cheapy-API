using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
    }
}
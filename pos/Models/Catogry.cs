﻿using System.ComponentModel.DataAnnotations;

namespace pos.Models
{
    public class Catogry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

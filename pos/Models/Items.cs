using System.ComponentModel.DataAnnotations;

namespace pos.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Des { get; set; }
        [Required]
        public double Price { get; set; }
        public int Count { get; set; }
    }
}

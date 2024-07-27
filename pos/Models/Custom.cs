using System.ComponentModel.DataAnnotations;

namespace pos.Models
{
    public class Custom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Number_phone { get; set; }

    }
}

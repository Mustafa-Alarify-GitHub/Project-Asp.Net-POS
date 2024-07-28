using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pos.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Des { get; set; }

        public string? Img { get; set; }


        [NotMapped]
        public IFormFile formFile { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        [ForeignKey("cat_id")]
        public Catogry? catogry { get; set; }
    }
}

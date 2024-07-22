

namespace WebStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Old Price")]
        [Range(1, 1000)]
        public double OldPrice { get; set; }

        [Required]
        [Display(Name = "New Price")]
        [Range(1, 1000)]
        public double NewPrice { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        
        public string ?ImageName { get; set; }
    }
}

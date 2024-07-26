using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebStore.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        [Required]
        public int ProductId {  get; set; }
        [ValidateNever]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [Required]
        public string ApplicationUserId {  get; set; }
        [ValidateNever]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public int Count {  get; set; }
    }
}

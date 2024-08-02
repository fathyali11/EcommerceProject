

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebStore.ViewModels
{
    public class CreateProductViewModel
    {
        public Models.Product product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> categoriesSelectedList { set; get; }
        [ImageExtension(FileSettings.ImageExtensions)]
        public IFormFile ImageFile {  get; set; }
    }
}

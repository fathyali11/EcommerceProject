namespace WebStore.Attributes
{
    public class ImageExtensionAttribute:ValidationAttribute
    {
        private readonly string fileExtensions;

        public ImageExtensionAttribute(string fileExtensions)
        {
            this.fileExtensions = fileExtensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var image=value as IFormFile;
            if (image != null)
            {
                var extension = Path.GetExtension(image.FileName);
                var IsFound = fileExtensions.Split(',').Contains(extension);
                if (!IsFound)
                    return new ValidationResult($"not allowed extension!\nAllowed Extensions Are {fileExtensions}");
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}

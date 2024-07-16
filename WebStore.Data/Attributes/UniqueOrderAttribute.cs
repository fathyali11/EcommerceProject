
using System.ComponentModel.DataAnnotations;
using WebApplication_Data;
using WebApplication_Models;

namespace WebApplication_Attributes
{
    public class UniqueOrderAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Resolve ApplicationDbContext from the validation context
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (context == null)
            {
                throw new InvalidOperationException("ApplicationDbContext is not available.");
            }

            var order = (int)value;
            var instance = validationContext.ObjectInstance as Category;
            if (instance == null)
            {
                throw new InvalidOperationException("Validation context object instance is not a Category.");
            }

            var isFound = context.Categories.FirstOrDefault(c => c.CategoryOrder == order && c.Id != instance.Id);

            if (isFound is not null)
            {
                return new ValidationResult($"This Order Was Taken. Please Choose Another One.");
            }

            return ValidationResult.Success;
        }
    }
}

using FluentValidation;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.IdCategory)
                .GreaterThan(0).WithMessage("The Category field must be filled in.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The Product Name field cannot be empty.")
                .MaximumLength(40).WithMessage("The Product Name field cannot exceed 40 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("The Product Description field cannot be empty.")
                .MaximumLength(100).WithMessage("The Product Description field cannot exceed 100 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("The Price field must be filled in.");

            RuleFor(p => p.RegistrationDate)
                .NotEmpty().WithMessage("The Registration Date field cannot be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The Registration Date field cannot be in the future.");
        }
    }
}

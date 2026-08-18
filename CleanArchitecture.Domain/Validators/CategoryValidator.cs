using FluentValidation;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("The Category Description field cannot be empty.")
                .MaximumLength(100).WithMessage("The Category Description field cannot exceed 100 characters.");

            RuleFor(p => p.RegistrationDate)
                .NotEmpty().WithMessage("The Registration Date field cannot be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The Registration Date field cannot be in the future.");
        }
    }
}

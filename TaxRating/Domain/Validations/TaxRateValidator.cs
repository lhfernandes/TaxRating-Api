using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class TaxRateValidator : AbstractValidator<TaxRate>
    {
        public TaxRateValidator()
        {
            RuleFor(t => t.Symbol)
                .NotNull()
                .NotEmpty().WithMessage("The Prefix must be not empty.")
                .MinimumLength(3).WithMessage("The Prefix must be at least 3 characters")
                .MaximumLength(4).WithMessage("The Prefix must be less than 4 characters");
        }
    }
}

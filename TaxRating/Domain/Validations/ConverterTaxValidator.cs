using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class ConverterTaxValidator : AbstractValidator<ConverterTax>
    {
        public ConverterTaxValidator()
        {
            RuleFor(t => t.Amount)
                .NotNull()
                .GreaterThan(0).WithMessage("The Amount must be greater than 0");

            RuleFor(t => t.Symbol)
               .NotNull()
               .NotEmpty().WithMessage("The Prefix must be not empty.");
        }
    }
}

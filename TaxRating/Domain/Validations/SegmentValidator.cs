using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class SegmentValidator : AbstractValidator<Segment>
    {
        public SegmentValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty().WithMessage("The name must be not empty.")
                .MinimumLength(5).WithMessage("The Name must be at least 5 characters")
                .MaximumLength(50).WithMessage("The Name must be less than 50 characters");

            RuleFor(t => t.Tax)
               .NotNull().WithMessage("The tax must be not empty.");
                          
        }
    }
}

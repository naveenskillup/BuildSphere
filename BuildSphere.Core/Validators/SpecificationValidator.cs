
using BuildSphere.Data.Repository.Definitions;
using FluentValidation;

namespace BuildSphere.Core.Validators
{
    public class SpecificationValidator : AbstractValidator<Specification>
    {
        public SpecificationValidator() 
        {
            RuleFor(spec => spec.Name)
                .NotEmpty().WithMessage("Specification name is required")
                .MaximumLength(100).WithMessage("Must be at most 100 characters");
        }
    }
}

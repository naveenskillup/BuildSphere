
using BuildSphere.Data.Repository.Definitions;
using FluentValidation;

namespace BuildSphere.Core.Validators
{
    public class SpecificationValidator : AbstractValidator<Specification>
    {
        public SpecificationValidator() 
        {
            RuleFor(spec => spec.Name)
                .Length(2, 100).WithMessage("Milestone name must be between 2 and 100 characters");
        }
    }
}

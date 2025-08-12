
using BuildSphere.Common.Definitions;
using FluentValidation;

namespace BuildSphere.Core.Validators
{
    public class MilestoneValidator : AbstractValidator<Milestone>
    {
        public MilestoneValidator()
        {
            RuleFor(milestone => milestone.Name)
                .IsInEnum().WithMessage("Milestone name is required");
        }
    }   
}

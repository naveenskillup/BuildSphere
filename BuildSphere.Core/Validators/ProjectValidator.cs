using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Data.Repository.Definitions;
using FluentValidation;

namespace BuildSphere.Core.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator() 
        {
            RuleFor(project => project.Name)
                .NotEmpty().NotEmpty().WithMessage("Project name is required")
                .MaximumLength(100).WithMessage("Must be at most 100 characters");

            RuleForEach(project => project.Specifications)
                .SetValidator(new SpecificationValidator());

            RuleForEach(project => project.Milestones)
                .SetValidator(new MilestoneValidator());
        }
    }
}

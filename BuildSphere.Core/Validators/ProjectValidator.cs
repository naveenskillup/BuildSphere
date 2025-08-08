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
                .Length(2, 100).WithMessage("Project Name must be between 2 and 100 characters");

            RuleForEach(project => project.Specifications)
                .SetValidator(new SpecificationValidator())
                .When(project => project.Specifications?.Any() == true);

            RuleForEach(project => project.Milestones)
                .SetValidator(new MilestoneValidator())
                .When(project => project.Milestones?.Any() == true);
        }
    }
}

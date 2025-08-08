using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Data.Repository.Definitions;
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

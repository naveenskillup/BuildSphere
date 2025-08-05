using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Core.Interfaces;
using BuildSphere.Core.Validators;
using BuildSphere.Data.Repository.Definitions;
using BuildSphere.Data.Repository.Interfaces;

namespace BuildSphere.Core.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectService(IProjectRepository projectRepository, IMilestoneRepository milestoneRepository,
        ISpecificationRepository specificationRepository)
        {
            _projectRepository = projectRepository;
            _specificationRepository = specificationRepository;
            _milestoneRepository = milestoneRepository;
        }

        public async Task Create(Project project)
        {
            var validationResult = await _validator.ValidateAsync(project);
            //need to handle this cases
            //validationResult.Errors.Select( e => e.ErrorMessage).ToList()
            if (project == null)
                return;

            await _projectRepository.Create(project);

            if (project.Specifications?.Any() == true)
            {
                foreach (var specification in project.Specifications)
                    await _specificationRepository.Create(project.Id, specification);

            }

            if (project.Milestones?.Any() == true)
            {
                foreach(var milestone in project.Milestones)
                    await _milestoneRepository.Create(project.Id, milestone);
                    
            }
        }

        private readonly ProjectValidator _validator = new ProjectValidator();
        private readonly IProjectRepository _projectRepository;
        private readonly IMilestoneRepository _milestoneRepository;
        private readonly ISpecificationRepository _specificationRepository;
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using BuildSphere.Common.Interfaces;

namespace BuildSphere.Common.Definitions
{ 
    public class Project : IIdentifiable
    {
        /// <summary>
        /// Unique identifier for the project.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the builder who is responsibile for project.
        /// </summary>
        public int BuilderId { get; set; }

        /// <summary>
        /// Identifier of the owner whom the project is being built.
        /// </summary>
        public int HomeownerId { get; set; }

        /// <summary>
        /// Name of the project(i.e., Naveen's house).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date that the project is agreed
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Expected date for handovering the project to the houseowner.
        /// </summary>
        public DateTime? ExpectedCloseDate { get; set; }

        /// <summary>
        /// Advance amount that is been given to abide the agreement.
        /// </summary>
        public decimal AdvanceAmount { get; set; }

        /// <summary>
        /// The specifications that is been included in the house.
        /// </summary>
        [NotMapped]
        public List<Specification>? Specifications { get; set; }

        /// <summary>
        /// The amount that need to be settled in each milestone.
        /// (i.e., after the completion of the basement 1 lack should be given).
        /// </summary>
        [NotMapped]
        public List<Milestone>? Milestones { get; set; }
    }
}

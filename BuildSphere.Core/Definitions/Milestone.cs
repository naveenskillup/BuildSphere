using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Core.Interfaces;

namespace BuildSphere.Core.Definitions
{
    /// <summary>
    /// It is step at which the payment need to be settled to the builder for the project.
    /// </summary>
    public class Milestone : IIdentifiable
    {
        /// <summary>
        /// Unique identifier for the milestone.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the project whose this milestone belongs to.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Step at which the payment need to be settled.
        /// </summary>
        public MilestoneType Name { get; set; }

        /// <summary>
        /// How much amount need to be paid for the Milestone.
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// When the payment is made for the milestone.
        /// </summary>
        public DateTime? PaidDate { get; set; }
    }

    public enum MilestoneType
    {
        Basement,
        Roofing,
        Drywall,
        Interior,
        Exterior,
        Handover
    }
}

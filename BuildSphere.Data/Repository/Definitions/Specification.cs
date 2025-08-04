using BuildSphere.Data.Repository.Interfaces;

namespace BuildSphere.Data.Repository.Definitions
{
    /// <summary>
    /// Specifications of the house.
    /// (i.e., uses ultratech cement for the construction, 4 windows for the entire house and made up of Neem).
    /// </summary>
    public class Specification : IIdentifiable
    {
        /// <summary>
        /// Unique identifier for the specification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Specification name (i.e., cement = ultratech).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the meterial that is used for the specification.
        /// (i.e., plywood meterial for the windows).
        /// </summary>
        public string MeterialType { get; set; }

        /// <summary>
        /// Quantity that is been used (i.e, 5 windows for the entire house).
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// If wanted to write any additional info.
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}

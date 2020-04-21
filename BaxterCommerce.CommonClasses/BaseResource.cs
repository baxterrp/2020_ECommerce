using System;

namespace BaxterCommerce.CommonClasses
{
    /// <summary>
    /// Base identified resource
    /// </summary>
    public abstract class BaseResource
    {
        /// <summary>
        /// Primary identifier of the resource
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date the resource was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Last date the resource was modified
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}

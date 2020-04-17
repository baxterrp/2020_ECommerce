using System;

namespace eCommerceReplacementProject.CommonClasses
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}

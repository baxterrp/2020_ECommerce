using System;

namespace eCommerceReplacementProject.DataRepository
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseTableConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public BaseTableConfiguration(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Find { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Insert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Update { get; set; }
    }
}

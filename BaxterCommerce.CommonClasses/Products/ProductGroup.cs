﻿namespace BaxterCommerce.CommonClasses.Products
{
    /// <summary>
    /// Category for grouping <see cref="Product"/> together
    /// </summary>
    public class ProductGroup : BaseResource
    {
        /// <summary>
        /// Descriptive name of category
        /// </summary>
        public string Name { get; set; }
    }
}

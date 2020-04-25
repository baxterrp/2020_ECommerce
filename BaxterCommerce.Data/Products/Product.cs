using BaxterCommerce.CommonClasses;

namespace BaxterCommerce.Data.Products
{
    /// <summary>
    /// A product for selling in shopping cart
    /// </summary>
    public class Product : BaseResource
    {
        /// <summary>
        /// The name of the <see cref="Product"/>
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Location of image file
        /// </summary>
        public string ImageLocation { get; set; }

        /// <summary>
        /// Price of <see cref="Product"/>
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Detailed description of <see cref="Product"/>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product is available for sale
        /// </summary>
        public bool IsActive { get; set; }
    }
}

using BaxterCommerce.CommonClasses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// Client for sending HTTP requests regarding <see cref="ProductGroup"/>
    /// </summary>
    public interface ICreateProductGroupClient
    {
        /// <summary>
        /// Creates new <see cref="ProductGroup"/>
        /// </summary>
        /// <param name="productGroup"><see cref="ProductGroup"/></param>
        /// <returns>The added <see cref="ProductGroup"/></returns>
        Task<ProductGroup> AddProductGroup(ProductGroup productGroup);
    }
}

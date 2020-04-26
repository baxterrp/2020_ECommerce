using BaxterCommerce.CommonClasses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Web.Services
{
    /// <summary>
    /// Service for handling <see cref="ProductGroup"/>
    /// </summary>
    public interface IProductGroupService
    {
        /// <summary>
        /// Creates a new <see cref="ProductGroup"/>
        /// </summary>
        /// <param name="productGroup"><see cref="ProductGroup"/></param>
        /// <returns>The added <see cref="ProductGroup"/></returns>
        Task<ProductGroup> AddProductGroup(ProductGroup productGroup);

        /// <summary>
        /// Finds all <see cref="ProductGroup"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="ProductGroup"/></returns>
        Task<IEnumerable<ProductGroup>> GetAllProductGroups();
    }
}

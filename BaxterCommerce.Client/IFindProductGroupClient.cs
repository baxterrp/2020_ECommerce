using BaxterCommerce.CommonClasses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Client
{
    /// <summary>
    /// For performing Get requests on <see cref="ProductGroup"/>
    /// </summary>
    public interface IFindProductGroupClient
    {
        /// <summary>
        /// Gets all <see cref="ProductGroup"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="ProductGroup"/></returns>
        Task<IEnumerable<ProductGroup>> GetAllProductGroups();
    }
}

using BaxterCommerce.CommonClasses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.Products
{
    /// <summary>
    /// Repository for handling <see cref="ProductGroup"/>
    /// </summary>
    public interface IProductGroupRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productGroup"></param>
        Task Insert(ProductGroup productGroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductGroup>> Find(ProductGroupSearchParameters parameters);
    }
}

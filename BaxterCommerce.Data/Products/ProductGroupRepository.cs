using BaxterCommerce.CommonClasses.Products;
using BaxterCommerce.Data.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Data.Products
{
    /// <summary>
    /// Repository for handling <see cref="ProductGroup"/>
    /// </summary>
    public class ProductGroupRepository : BaseDataRepository<ProductGroup>, IProductGroupRepository
    {
        public ProductGroupRepository(ConnectionConfiguration connectionConfiguration, BaseTableConfiguration tableConfiguration)
            : base(connectionConfiguration, tableConfiguration)
        {
        }

        /// <summary>
        /// Implements <see cref="IProductGroupRepository.Find(ProductGroupSearchParameters)"/>
        /// </summary>
        public async Task<IEnumerable<ProductGroup>> Find(ProductGroupSearchParameters parameters) =>
             await base.Find(parameters);
    }
}

using BaxterCommerce.CommonClasses.Products;
using BaxterCommerce.Data.Logging;
using BaxterCommerce.Data.Products;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Web.Services.Products
{
    /// <summary>
    /// Service for handling <see cref="ProductGroup"/>
    /// </summary>
    public class ProductGroupService : IProductGroupService
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly ILogger _logger;

        public ProductGroupService(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository ?? throw new ArgumentNullException(nameof(productGroupRepository));
            _logger = LoggerFactory.CreateLogger();
        }

        /// <summary>
        /// Implements <see cref="IProductGroupService.AddProductGroup(ProductGroup)"/>
        /// </summary>
        public async Task<ProductGroup> AddProductGroup(ProductGroup productGroup)
        {
            productGroup.Id = Guid.NewGuid().ToString();
            productGroup.CreatedAt = DateTime.Now;
            productGroup.UpdatedAt = DateTime.Now;

            await _productGroupRepository.Insert(productGroup);

            return productGroup;
        }

        /// <summary>
        /// Implements <see cref="IProductGroupService.GetAllProductGroups"/>
        /// </summary>
        public async Task<IEnumerable<ProductGroup>> GetAllProductGroups()
        {
            return await _productGroupRepository.Find(new ProductGroupSearchParameters());
        }
    }
}

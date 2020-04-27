using BaxterCommerce.CommonClasses.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaxterCommerce.Client.Products
{
    /// <summary>
    /// Implements <see cref="IFindProductGroupClient"/>
    /// </summary>
    public class FindProductGroupClient : BaseHttpRequestClient<ProductGroup, IEnumerable<ProductGroup>>, IFindProductGroupClient
    {
        private static readonly string _baseProductGroupURI = "/groups";

        public FindProductGroupClient(ClientConfiguration clientConfiguration) : base(clientConfiguration) { }

        /// <summary>
        /// Implements <see cref="IFindProductGroupClient.GetAllProductGroups"/>
        /// </summary>
        public async Task<IEnumerable<ProductGroup>> GetAllProductGroups() =>
            await SendGetRequest(_baseProductGroupURI);
    }
}

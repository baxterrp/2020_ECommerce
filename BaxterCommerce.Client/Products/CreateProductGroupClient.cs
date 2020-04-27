using BaxterCommerce.CommonClasses.Products;
using System.Threading.Tasks;

namespace BaxterCommerce.Client.Products
{
    /// <summary>
    /// Implements <see cref="ICreateProductGroupClient"/>
    /// </summary>
    public class CreateProductGroupClient : BaseHttpRequestClient<ProductGroup, ProductGroup>, ICreateProductGroupClient
    {
        private static readonly string _baseProductGroupURI = "/groups";

        public CreateProductGroupClient(ClientConfiguration clientConfiguration) : base(clientConfiguration) { }

        /// <summary>
        /// Implements <see cref="ICreateProductGroupClient.AddProductGroup(ProductGroup)"/>
        /// </summary>
        public async Task<ProductGroup> AddProductGroup(ProductGroup productGroup) =>
            await SendPostRequest(_baseProductGroupURI, productGroup);
    }
}

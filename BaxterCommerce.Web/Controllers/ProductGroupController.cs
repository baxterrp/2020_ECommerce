using BaxterCommerce.CommonClasses.Products;
using BaxterCommerce.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaxterCommerce.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductGroupController : Controller
    {
        private readonly IProductGroupService _productGroupService;

        public ProductGroupController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService ?? throw new ArgumentNullException(nameof(productGroupService));
        }

        [HttpPost("/groups")]
        public async Task<IActionResult> AddGroup([FromBody]ProductGroup productGroup)
        {
            var addedGroup = await _productGroupService.AddProductGroup(productGroup);

            return Ok(addedGroup);
        }

        [HttpGet("/groups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _productGroupService.GetAllProductGroups();

            return Ok(groups);
        }
    }
}
using BaxterCommerce.CommonClasses.Products;
using BaxterCommerce.Data.Logging;
using BaxterCommerce.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaxterCommerce.Web.Controllers
{
    /// <summary>
    /// Controller for handling <see cref="ProductGroup"/>
    /// </summary>
    public class ProductGroupController : Controller
    {
        private readonly IProductGroupService _productGroupService;
        private readonly ILogger _logger;

        public ProductGroupController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService ?? throw new ArgumentNullException(nameof(productGroupService));
            _logger = LoggerFactory.CreateLogger();
        }
        
        /// <summary>
        /// Creates a new <see cref="ProductGroup"/>
        /// </summary>
        /// <param name="productGroup"><see cref="ProductGroup"/> to add</param>
        /// <returns>Created <see cref="ProductGroup"/></returns>
        [HttpPost("/groups")]
        public async Task<IActionResult> AddGroup([FromBody]ProductGroup productGroup)
        {
            if (productGroup is null) throw new ArgumentNullException(nameof(productGroup));
            if (string.IsNullOrWhiteSpace(productGroup.Name)) throw new ArgumentNullException(nameof(productGroup.Name));

            try
            {
                _logger.Debug("Adding new group with name {name}", productGroup.Name);
                var addedGroup = await _productGroupService.AddProductGroup(productGroup);

                return Ok(addedGroup);
            }
            catch(Exception exception)
            {
                _logger.Debug(exception.ToString());
                throw;
            }
        }

        /// <summary>
        /// Does query for all groups
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="ProductGroup"/></returns>
        [HttpGet("/groups")]
        public async Task<IActionResult> GetAllGroups()
        {
            try 
            { 
                _logger.Debug("Finding all groups");
                var groups = await _productGroupService.GetAllProductGroups();

                _logger.Debug("Found groups {groupnames}", string.Join(",", groups.Select(group => group.Name)));

                return Ok(groups);
            }
            catch (Exception exception)
            {
                _logger.Debug(exception.ToString());
                throw;
            }
        }
    }
}
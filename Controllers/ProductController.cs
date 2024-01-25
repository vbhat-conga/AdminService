using AdminService.Model;
using AdminService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminService.Controllers
{
    /// <summary>
    /// TODO: Lot of thinks need to be revisited
    /// Response generalization
    /// Error Handling etc.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ActivitySource _activitySource = new(Instrumentation.ActivitySourceName);
        public ProductController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProducts(IEnumerable<Product> products)
        {
            if (!ModelState.IsValid)
                  return BadRequest(new ApiResponse<IEnumerable<Guid>>(null, "400", "Validation error"));

            var productIds = await _adminService.SaveProducts(products);
            if(productIds.Any())
            {
                var apiResponse = new ApiResponse<IEnumerable<Guid>>(productIds, "201");
                return Created($"{Request.Path}/", apiResponse);
            }
            return StatusCode(500);
        }

        [HttpPost("query")]
        public async Task<ActionResult> GetProducts(IEnumerable<string> ids)
        {
            using var activity = _activitySource.StartActivity($"{nameof(ProductController)} : GetProducts", ActivityKind.Server);
            var products = await _adminService.GetProducts(ids);
            var apiResponse = new ApiResponse<IEnumerable<Product>>(products, "200");
            return Ok(apiResponse);
        }

    }
}

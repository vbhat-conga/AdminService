using AdminService.Model;
using AdminService.Service;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public ProductController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProducts(IEnumerable<Product> products)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = await _adminService.GetProducts(ids);
            var apiResponse = new ApiResponse<IEnumerable<Product>>(products, "200");
            return Ok(apiResponse);
        }

    }
}

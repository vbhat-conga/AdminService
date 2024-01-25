using AdminService.DataModel;
using AdminService.Model;
using AdminService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    /// <summary>
    /// TODO: Lot of thinks need to be revisited
    /// Response generalization
    /// Error Handling etc.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public PriceListController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePriceList(IEnumerable<PriceList> priceList)
        {
            if (!ModelState.IsValid)
                 return BadRequest(new ApiResponse<string>(null, "400", "Validation error"));
            var pricelistIds = await _adminService.SavePricelist(priceList);
            if (pricelistIds.Any())
            {
                var apiResponse = new ApiResponse<IEnumerable<Guid>>(pricelistIds, "201");
                return Created($"{Request.Path}/", apiResponse);
            }
            return StatusCode(500);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceList>> GetPriceList([FromRoute] Guid id)
        {
            var priceList = await _adminService.GetPriceList(id);
            if (priceList == null)
                return NotFound(new ApiResponse<string>(null, "404", "Not found"));

            var apiResponse = new ApiResponse<PriceList>(priceList, "200");
            return Ok(apiResponse);


        }


        [HttpPost("{id}/products")]
        public async Task<ActionResult> AddPriceListItems([FromRoute] Guid id, IEnumerable<PriceListItem> ids)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<string>(null, "400", "Validation error"));
            var products = await _adminService.SavePricelistItem(id, ids);
            var apiResponse = new ApiResponse<IEnumerable<Guid>>(products, "200");
            return Created($"{Request.Path}/", apiResponse);
        }

        [HttpPost("{id}/pricelistitems/query")]
        public async Task<ActionResult> GetPriceListItems([FromRoute] Guid id, PriceListItemQueryRequest priceListItemQueryRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<string>(null, "400", "Validation error"));
            var products = await _adminService.GetPriceListItemByPriceListId(id, priceListItemQueryRequest);
            var apiResponse = new ApiResponse<IEnumerable<PriceListItemData>>(products, "200");
            return Ok(apiResponse);
        }
    }
}

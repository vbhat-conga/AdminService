using AdminService.DataModel;
using AdminService.Model;
using AdminService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
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
                return BadRequest(ModelState);
            var pricelistIds = await _adminService.SavePricelist(priceList);
            if(pricelistIds.Any())
            {
                var apiResponse = new ApiResponse<IEnumerable<Guid>>(pricelistIds, "201");
                return Created($"{Request.Path}/", apiResponse);
            }
            return StatusCode(500);
        }


        [HttpPost("{id}/products")]
        public async Task<ActionResult> AddPriceListItems([FromRoute] Guid id,IEnumerable<PriceListItem> ids)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = await _adminService.SavePricelistItem(id, ids);
            var apiResponse = new ApiResponse<IEnumerable<Guid>>(products, "200");
            return Created($"{Request.Path}/", apiResponse);
        }

        [HttpPost("{id}/pricelistitems/query")]
        public async Task<ActionResult> GetPriceListItems([FromRoute] Guid id, PriceListItemQueryRequest priceListItemQueryRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = await _adminService.GetPriceListItemByPriceListId(id, priceListItemQueryRequest);
            var apiResponse = new ApiResponse<IEnumerable<PriceListItemData>>(products, "200");
            return Ok(apiResponse);
        }
    }
}

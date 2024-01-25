using System.ComponentModel.DataAnnotations;

namespace AdminService.Model
{
    public class PriceListItemQueryRequest
    {
        [Required]
        public IEnumerable<Guid> Ids { get; set; }
        public IEnumerable<string>? QueryFields { get; set; }
    }
}

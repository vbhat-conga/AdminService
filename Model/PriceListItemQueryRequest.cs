namespace AdminService.Model
{
    public class PriceListItemQueryRequest
    {
        public IEnumerable<Guid> Ids { get; set; }
        public IEnumerable<string> QueryFields { get; set; }
    }
}

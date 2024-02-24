using RestWithASPNETDarlan.Hypermedias.Abstract;

namespace RestWithASPNETDarlan.Hypermedias.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }

}

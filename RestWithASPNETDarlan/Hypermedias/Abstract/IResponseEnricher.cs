using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASPNETDarlan.Hypermedias.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}

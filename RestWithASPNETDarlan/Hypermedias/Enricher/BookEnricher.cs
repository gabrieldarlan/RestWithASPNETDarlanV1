using Microsoft.AspNetCore.Mvc;
using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Hypermedias.Constants;
using System.Text;

namespace RestWithASPNETDarlan.Hypermedias.Enricher
{
    public class BookEnricher : ContentResponseEnricher<BookVO>
    {

        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            var path = "api/book";
            string link = getLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet,
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut,
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPatch,
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost,
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int",
            });

            return Task.CompletedTask;
        }

        private string getLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                var url = new
                {
                    controller = path,
                    id,
                };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString(); ;
            }
        }
    }
}

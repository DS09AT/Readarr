using System.Collections.Generic;
using System.Linq;
using Shelvance.Http.REST;

namespace Shelvance.Api.V1.Series
{
    public class SeriesResource : RestResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SeriesBookLinkResource> Links { get; set; }
    }

    public static class SeriesResourceMapper
    {
        public static SeriesResource ToResource(this Shelvance.Core.Books.Series model)
        {
            if (model == null)
            {
                return null;
            }

            return new SeriesResource
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Links = model.LinkItems.Value.ToResource()
            };
        }

        public static List<SeriesResource> ToResource(this IEnumerable<Shelvance.Core.Books.Series> models)
        {
            return models?.Select(ToResource).ToList();
        }
    }
}

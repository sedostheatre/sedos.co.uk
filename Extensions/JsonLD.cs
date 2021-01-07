using Statiq.Common;
using Schema.NET;
using System;
using System.Linq;

namespace Sedos.Extensions
{
    public class JsonLD
    {
        public static string Show(IDocument doc)
        {
            return new TheaterEvent()
            {
                Name = doc.Get("title", ""),
                StartDate = doc.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).OrderBy(x => x).FirstOrDefault(),
                Location = new Place() { Address = doc.Get("venue", ""), Name = doc.Get("venue", "") },
                SubEvent = new OneOrMany<IEvent>(doc.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).Select(x => new TheaterEvent()
                {
                    Name = doc.Get("title", ""),
                    StartDate = x,
                    Location = new Place() { Address = doc.Get("venue", ""), Name = doc.Get("venue", "") }
                }))
            }.ToHtmlEscapedString();
        }
    }
}

using Statiq.Common;
using Schema.NET;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Sedos.Extensions
{
    public class JsonLD
    {
        public static string Show(IDocument doc)
        {
            DateTimeOffset? startDate = doc.Get("showtimes", Enumerable.Empty<IDocument>()).Any()
                ? doc.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).OrderBy(x => x).FirstOrDefault()
                : null;

            var location = doc.ContainsKey("venue")
                ? new Place() { Address = doc.Get("venue", ""), Name = doc.Get("venue", "") }
                : null;

            return new TheaterEvent()
            {
                Name = doc.Get("title", ""),
                StartDate = startDate,
                Location = location,
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

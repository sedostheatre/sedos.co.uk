using Schema.NET;
using Statiq.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sedos.Helpers
{
    public class JsonLD
    {
        public static string Show(IDocument doc, IReadOnlyCollection<IDocument> venues)
        {
            DateTimeOffset? startDate = doc.Get("showtimes", Enumerable.Empty<IDocument>()).Any()
                ? doc.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).OrderBy(x => x).FirstOrDefault()
                : null;

            var location = GeneratePlace(doc.GetString("venue"), venues);

            return new TheaterEvent()
            {
                Name = doc.Get("title", ""),
                StartDate = startDate,
                Location = location,
                SubEvent = new OneOrMany<IEvent>(doc.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).Select(x => new TheaterEvent()
                {
                    Name = doc.GetString("title", ""),
                    StartDate = x,
                    Location = new Place() { Address = doc.GetString("venue", ""), Name = doc.GetString("venue", "") }
                }))
            }.ToHtmlEscapedString();
        }

        private static Place GeneratePlace(string venueName, IReadOnlyCollection<IDocument> venues)
        {
            if (venueName != null)
            {
                var venue = venues.FirstOrDefault(x => x["key"].ToString().Equals(venueName));
                if (venue != null)
                {
                    return new Place() { Address = venue.GetString("address"), Name = venue.GetString("name") };
                }
                else
                {
                    return new Place() { Address = venueName, Name = venueName };
                }
            }
            return null;
        }
    }
}

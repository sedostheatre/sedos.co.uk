using Schema.NET;
using Statiq.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sedos.Helpers
{
    public class JsonLD
    {
        private static Organization SedosOrganization = new()
        {
            Name = Constants.Sedos,
            Url = new UriBuilder(Constants.Domain)
            {
                Scheme = Uri.UriSchemeHttps,
                Port = -1
            }.Uri
        };

        public static string Show(IDocument doc, IReadOnlyCollection<IDocument> venues)
        {
            DateTimeOffset? startDate = doc.Get("showtimes", Enumerable.Empty<IDocument>()).Any()
                ? doc.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).OrderBy(x => x).FirstOrDefault()
                : null;

            var location = GeneratePlace(doc.GetString("venue"), venues);
            var flyer = GenerateImage(doc.GetString("flyer"));

            return new TheaterEvent()
            {
                Name = doc.Get("title", ""),
                StartDate = startDate,
                Location = location,
                Description = doc.Get("metaDescription", ""),
                Organizer = SedosOrganization,
                Image = flyer,
                Offers = GenerateOffer(doc),
                SubEvent = new OneOrMany<IEvent>(doc.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).Select(x => new TheaterEvent()
                {
                    Name = doc.GetString("title", ""),
                    StartDate = x,
                    Location = location,
                    Description = doc.Get("metaDescription", ""),
                    Organizer = SedosOrganization,
                    Image = flyer
                }))
            }.ToHtmlEscapedString();
        }

        private static Place GeneratePlace(string venueName, IReadOnlyCollection<IDocument> venues)
        {
            if (venueName != null)
            {
                var venue = venues.FirstOrDefault(x => x["name"].ToString().Equals(venueName));
                if (venue != null)
                {
                    return new Place() { Address = new PostalAddress
                    {
                        AddressCountry = venue.GetString("country"),
                        StreetAddress = venue.GetString("streetAddress"),
                        AddressLocality = venue.GetString("city"),
                        PostalCode = venue.GetString("postCode")
                    }, Name = venue.GetString("name") };
                }
                else
                {
                    return new Place() { Address = venueName, Name = venueName };
                }
            }
            return null;
        }

        private static Uri GenerateImage(string flyer)
        {
            if (flyer == null) return null;
            return new UriBuilder(String.Concat(Constants.Domain, flyer))
            {
                Scheme = Uri.UriSchemeHttps,
                Port = -1
            }.Uri;
        }

        private static Offer GenerateOffer(IDocument show)
        {
            DateTimeOffset? endDate = show.Get("showtimes", Enumerable.Empty<IDocument>()).Any()
                ? show.Get("showtimes", Enumerable.Empty<IDocument>()).Select(x => x.Get<DateTimeOffset>("time")).OrderBy(x => x).Reverse().FirstOrDefault()
                : null;

            if (endDate >= DateTime.Today && show.GetBool("box-office-open", false))
            {
                var bookingLink = BoxOfficeUri.FromBoxOfficeLink(show.GetString("box-office-link"));
                return new Offer
                {
                    Url = bookingLink,
                    PriceCurrency = "GBP"
                };
            }

            return null;
        }
    }
}

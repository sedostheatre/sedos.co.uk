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

        // Rough running time used to derive an endDate for individual
        // performances when none is provided in frontmatter.
        private static readonly TimeSpan PerformanceDuration = TimeSpan.FromHours(2.5);

        private static readonly PerformingGroup SedosPerformer = new()
        {
            Name = Constants.Sedos
        };

        public static string Show(IDocument doc, IReadOnlyCollection<IDocument> venues, string url)
        {
            var showtimes = doc.Get("showtimes", Enumerable.Empty<IDocument>())
                .Select(x => x.Get<DateTimeOffset>("time"))
                .OrderBy(x => x)
                .ToList();

            DateTimeOffset? startDate = showtimes.Any() ? showtimes.First() : null;
            DateTimeOffset? endDate = showtimes.Any() ? showtimes.Last() : null;

            var location = GeneratePlace(doc.GetString("venue"), venues);
            var flyer = GenerateImage(doc.GetString("flyer"));
            var offer = GenerateOffer(doc);

            var theaterEvent = BuildEvent(doc, url, startDate, endDate, location, flyer, offer);
            theaterEvent.SubEvent = new OneOrMany<IEvent>(showtimes.Select(x =>
                BuildEvent(doc, url, x, x + PerformanceDuration, location, flyer, offer)));

            return theaterEvent.ToHtmlEscapedString();
        }

        private static TheaterEvent BuildEvent(IDocument doc, string url, DateTimeOffset? startDate, DateTimeOffset? endDate, Place location, Uri flyer, Offer offer)
        {
            return new TheaterEvent()
            {
                Name = doc.Get("title", ""),
                Url = url != null ? new Uri(url) : null,
                StartDate = startDate,
                EndDate = endDate,
                Location = location,
                Description = doc.Get("metaDescription", ""),
                Organizer = SedosOrganization,
                Performer = SedosPerformer,
                Image = flyer,
                EventStatus = EventStatusType.EventScheduled,
                Offers = offer
            };
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
                var offer = new Offer
                {
                    Url = bookingLink,
                    PriceCurrency = "GBP",
                    Availability = ItemAvailability.InStock
                };

                var price = show.GetString("price");
                if (!string.IsNullOrWhiteSpace(price))
                {
                    offer.Price = price;
                }

                return offer;
            }

            return null;
        }
    }
}

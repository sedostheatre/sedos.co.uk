using System;

namespace Sedos {
    public static class BoxOfficeUri {
        
        private static readonly Uri BASE = new Uri("https://sedos.ticketsolve.com/shows/");

        public static Uri FromShowId(string? showId) {
            return new Uri(BASE, showId);
        }

    }
}

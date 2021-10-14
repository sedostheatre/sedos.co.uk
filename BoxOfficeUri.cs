using System;

namespace Sedos {
    public static class BoxOfficeUri {

        public static Uri FromBoxOfficeLink(string boxOfficeLink) {
            return new UriBuilder(boxOfficeLink) {
                Scheme = Uri.UriSchemeHttps,
                Port = -1
            }.Uri;
        }

    }
}

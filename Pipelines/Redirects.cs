using Statiq.Common;
using Statiq.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sedos.Pipelines
{
    public class Redirects : Pipeline
    {
        public Redirects()
        {
            Dependencies.AddRange(nameof(AboutSections), nameof(AllShows), nameof(News), nameof(Index), nameof(RegularEvents), nameof(TopLevelPages), nameof(MarkdownPages));

            var temporaryCustomRedirects = new Dictionary<string, string>() {
                { "deiform", "https://docs.google.com/forms/d/e/1FAIpQLSeYkPb8xUk6aWLo-ndd68Rs2k-YA5NQWcd3A5rMP5tGVXK-yw/viewform" },
                { "newsletter", "https://mailchi.mp/sedos.co.uk/newsletter-sign-up" },
                { "carrie/form", "https://docs.google.com/forms/d/e/1FAIpQLSdQciQq-Wmwivokfr1krlR4cMH8iR6O1rwkl6205R0gBlf6TQ/viewform?usp=sf_link" },
                { "carrie/notice", "https://docs.google.com/document/d/1tBZGC5erP8yYSN-GJXR11TPhvIc746N0ZyU97deCyP4/edit?usp=sharing" },
                { "carrie/materials", "https://drive.google.com/drive/folders/1IUe23s-DjXNRFFgZ_NvrSvpiC_QPq_83?usp=sharing" },
                { "pitch-guidance", "https://docs.google.com/document/d/159UxLbbi21fYe78VHS3dzKZ7O_sBgRHCVNBpzx2KGA4/edit?usp=sharing" },
                { "pitch-form", "https://docs.google.com/document/d/1f9ARNOV5HFDcCZTzQpXk-qCtzHX3whlXh2HpEwB8wCA/edit?usp=sharing" },
                { "pitch-library", "https://drive.google.com/drive/folders/1GFwcyGoPsi7N8GQBBBlpg1lI7ex7O8_i?usp=drive_link" },
                { "sunshine/material", "https://drive.google.com/drive/folders/1eMb1eu5-fZxbYa3fpgw10hoGoDrpsrD3?usp=sharing" },
                { "sunshine/form", "https://forms.gle/59bymGMZ791kArsp8" },
                { "sunshine/notice", "https://drive.google.com/file/d/1lfh7yP1i_8OmpmQeSJR_CyTglQ2V3J_G/view?usp=share_link" },
                { "sunshine/recall", "https://drive.google.com/drive/folders/12XZ-xPPgOEVmxaChH51V_mHw9u8KOTZ2?usp=sharing" },
                { "september-2023-pitch-form", "https://docs.google.com/document/d/1Tu7-F-i1KQNtF72sZz4p_Xp1xisqESj4BAriVLXxp2Q/edit" },
                { "september-2023-pitch-guidance", "https://docs.google.com/document/d/1fPWJSJ7tM6FzxCI7Xsw3qZ8hN78nqCUod525xa7lzqM/edit" },
                { "clue/notice", "https://drive.google.com/file/d/12ZJ4Tvzu_7pEEgPLnhiq4fIcSkSy1IP9/view?usp=share_link" },
                { "clue/material", "https://drive.google.com/drive/folders/19uECe0mFu9Q4-qrOJrenqSEZDkfx9ckE?usp=sharing" },
                { "clue/form", "https://docs.google.com/forms/d/e/1FAIpQLSfHJd2PXh-YJypneFsrinoSAdc1-IE9U4-Sd7pIl0govmcp1g/viewform?usp=sf_link" },
                { "clue/waitlist", "https://forms.gle/htQbDmYtUfNT55kc9" },
                { "calendar", "https://calendar.google.com/calendar/u/1?cid=bXlzZWRvcy5jby51a19ib3Z1OWprZDNxYjlsbmM3ZDhrOTc2bHQ1Y0Bncm91cC5jYWxlbmRhci5nb29nbGUuY29t" },
                { "titanic/material", "https://drive.google.com/drive/folders/1_lJ2JBdruZ_Pd5JSyZsaID1sGdooI4hI?usp=sharing" },
                { "titanic/form", "https://forms.gle/hVyeGJebqC8cYTyV7" },
                { "titanic/notice", "https://drive.google.com/file/d/1mGqSJ4oplGMGNqe8z2FysYYTLo2dA43B/view?usp=drive_link" },
                { "titanic/waitlist", "https://forms.gle/MzNetGH44eHHJXdcA" },
                { "sondheim/programme", "https://marvelapp.com/prototype/jhg003h" },
                { "donate", "https://sedos.ticketsolve.com/ticketbooth/products/donation" },
                { "donate/programme", "https://www.sedos.co.uk/donate?utm_source=programme&utm_medium=qrcode&utm_campaign=supportus" },
                { "production/community", "https://chat.whatsapp.com/J3QApbmJlMZ9oYrlVGGkGU" },
                { "justso/material", "https://drive.google.com/drive/folders/12jf3KdeXp0iSfh9rsE5Nd2Lo62lzzCNX" },
                { "justso/form", "https://docs.google.com/forms/d/e/1FAIpQLSdAtaSZ4AoiN_x_ilttVSq-wJthyeCCHxBaS9IxrpFm9GGhZQ/viewform" },
                { "september-2024-pitch-form", "https://docs.google.com/document/d/1tCxS9i3uRrWv7ksV6L_Yn_aUC5a0B40K9R9Da3c_AOY/edit" },
                { "september-2024-pitch-guidance", "https://docs.google.com/document/d/1Iz6vsEuz4-Y1mClXD2l4PLRce4g761cn0Z6JfyK1Y5A/edit" },
                { "charliebrown", "https://www.sedos.co.uk/shows/2024-you-re-a-good-man-charlie-brown" },
                { "expenses", "https://docs.google.com/spreadsheets/d/1sSCNGxWBmmZN78Sh4UrgERRBsdDkDDe9/edit?usp=sharing&ouid=106113350928212210090&rtpof=true&sd=true" },
            };

            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(AboutSections), nameof(AllShows), nameof(News), nameof(Index), nameof(RegularEvents), nameof(TopLevelPages), nameof(MarkdownPages)),
                new GenerateRedirects()
                    .WithMetaRefreshPages(false)
                    .WithAdditionalOutput("_redirects", redirects =>
                    string.Join(Environment.NewLine, redirects.OrderBy(r => r.Key).Select(r => $"/{r.Key} {r.Value} 301")
                        .Append(string.Join(Environment.NewLine, temporaryCustomRedirects.Select(r => $"/{r.Key} {r.Value} 302"))))),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

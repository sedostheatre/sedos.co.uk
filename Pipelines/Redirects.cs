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
                { "deiform", "https://forms.gle/MjYUCXrfMByr8D55A" },
                { "newsletter", "https://mailchi.mp/sedos.co.uk/newsletter-sign-up" },
                { "carrie/form", "https://docs.google.com/forms/d/e/1FAIpQLSdQciQq-Wmwivokfr1krlR4cMH8iR6O1rwkl6205R0gBlf6TQ/viewform?usp=sf_link" },
                { "carrie/notice", "https://docs.google.com/document/d/1tBZGC5erP8yYSN-GJXR11TPhvIc746N0ZyU97deCyP4/edit?usp=sharing" },
                { "carrie/materials", "https://drive.google.com/drive/folders/1IUe23s-DjXNRFFgZ_NvrSvpiC_QPq_83?usp=sharing" },
                { "pitch-guidance", "https://docs.google.com/document/d/1VmBuK-rIYb5z8f3G-pqA5W31GD68Z-HT57vnOg2KX2o/edit?usp=sharing" },
                { "pitch-form", "https://docs.google.com/document/d/1cOV5QL3hYRbeBl7Zhm9HoreyuYjutE1XhILiNgYujpI/edit?usp=sharing" },
                { "sunshine/material", "https://drive.google.com/drive/folders/1eMb1eu5-fZxbYa3fpgw10hoGoDrpsrD3?usp=sharing" },
                { "sunshine/form", "https://forms.gle/59bymGMZ791kArsp8" },
                { "sunshine/notice", "https://drive.google.com/file/d/1lfh7yP1i_8OmpmQeSJR_CyTglQ2V3J_G/view?usp=share_link" },
                { "sunshine/recall", "https://drive.google.com/drive/folders/12XZ-xPPgOEVmxaChH51V_mHw9u8KOTZ2?usp=sharing" },
                { "september-2023-pitch-form", "https://docs.google.com/document/d/1Tu7-F-i1KQNtF72sZz4p_Xp1xisqESj4BAriVLXxp2Q/edit" },
                { "september-2023-pitch-guidance", "https://docs.google.com/document/d/1fPWJSJ7tM6FzxCI7Xsw3qZ8hN78nqCUod525xa7lzqM/edit" },
                { "clue/notice", "https://drive.google.com/file/d/12ZJ4Tvzu_7pEEgPLnhiq4fIcSkSy1IP9/view?usp=share_link" },
                { "clue/material", "https://drive.google.com/drive/folders/19uECe0mFu9Q4-qrOJrenqSEZDkfx9ckE?usp=sharing" },
                { "clue/form", "https://docs.google.com/forms/d/e/1FAIpQLSfHJd2PXh-YJypneFsrinoSAdc1-IE9U4-Sd7pIl0govmcp1g/viewform?usp=sf_link" }
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

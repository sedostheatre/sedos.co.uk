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
                { "idiot/form", "https://docs.google.com/forms/d/e/1FAIpQLSfwwilNjpYp4LtkLaE2zBQGO4fUVG288TGuSqa6DpA1ifyQGQ/viewform" },
                { "idiot/material", "https://drive.google.com/drive/folders/161ZgKRV_ZACJqwSpKZeeHQW6110i-WEJ?usp=sharing" },                
                { "idiot/materials", "https://drive.google.com/drive/folders/161ZgKRV_ZACJqwSpKZeeHQW6110i-WEJ?usp=sharing" },
                { "idiot/notice", "https://drive.google.com/file/d/1vROxdXRoRaENbBw9a-A_-19sl6d7IGah/view?usp=sharing" },
                { "carrie/form", "https://docs.google.com/forms/d/e/1FAIpQLSdQciQq-Wmwivokfr1krlR4cMH8iR6O1rwkl6205R0gBlf6TQ/viewform?usp=sf_link" },
                { "carrie/notice", "https://docs.google.com/document/d/1tBZGC5erP8yYSN-GJXR11TPhvIc746N0ZyU97deCyP4/edit?usp=sharing" },
                { "carrie/materials", "https://drive.google.com/drive/folders/1IUe23s-DjXNRFFgZ_NvrSvpiC_QPq_83?usp=sharing" },
            };

            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(AboutSections), nameof(AllShows), nameof(News), nameof(Index), nameof(RegularEvents), nameof(TopLevelPages), nameof(MarkdownPages)),
                new GenerateRedirects().WithAdditionalOutput("_redirects", redirects =>
                    string.Join(Environment.NewLine, redirects.OrderBy(r => r.Key).Select(r => $"/{r.Key} {r.Value} 301!")
                        .Append(string.Join(Environment.NewLine, temporaryCustomRedirects.Select(r => $"/{r.Key} {r.Value} 302!"))))),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

using Statiq.Common;
using Statiq.Core;
using System;
using System.Linq;

namespace Sedos.Pipelines
{
    public class Redirects : Pipeline
    {
        public Redirects()
        {
            Dependencies.AddRange(nameof(AllShows), nameof(News), nameof(TopLevelPages));

            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(AllShows), nameof(News), nameof(TopLevelPages)),
                new GenerateRedirects().WithAdditionalOutput("_redirects", redirects => string.Join(Environment.NewLine, redirects.OrderBy(r => r.Key).Select(r => $"/{r.Key} {r.Value} 301!"))),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

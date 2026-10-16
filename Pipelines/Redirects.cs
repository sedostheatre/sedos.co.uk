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
            Dependencies.AddRange(nameof(AboutSections), nameof(AllShows), nameof(News), nameof(Index), nameof(RegularEvents), nameof(TopLevelPages), nameof(MarkdownPages), nameof(ShortLinks));

            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(AboutSections), nameof(AllShows), nameof(News), nameof(Index), nameof(RegularEvents), nameof(TopLevelPages), nameof(MarkdownPages), nameof(SupportSections)),
                new GenerateRedirects()
                    .WithMetaRefreshPages(false)
                    .WithAdditionalOutput("_redirects", (redirects, context) =>
                    string.Join(Environment.NewLine, redirects.OrderBy(r => r.Key).Select(r => $"/{r.Key} {r.Value} 301")
                        .Concat(GetShortLinks(context).Select(r => $"/{r.From} {r.To} 302")))),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }

        private static IEnumerable<(string From, string To)> GetShortLinks(IExecutionContext context) =>
            context.Outputs.FromPipeline(nameof(ShortLinks))
                .SelectMany(d => d.GetList<IDocument>("links") ?? Enumerable.Empty<IDocument>())
                .Select(l => (From: l.GetString("from")?.Trim().Trim('/'), To: l.GetString("to")?.Trim()))
                .Where(l => !string.IsNullOrEmpty(l.From) && !string.IsNullOrEmpty(l.To));
    }
}

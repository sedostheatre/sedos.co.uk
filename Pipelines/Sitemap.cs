using Statiq.Common;
using Statiq.Core;
using Statiq.Web;

namespace Sedos.Pipelines
{
    public class Sitemap : Pipeline
    {
        public Sitemap()
        {
            var pipelinesToInclude = new[]
            {
                nameof(AboutSections),
                nameof(SupportSections),
                nameof(AllShows),
                nameof(News),
                nameof(Events),
                nameof(Index),
                nameof(MarkdownPages),
                nameof(RegularEvents),
                nameof(TopLevelPages),
                nameof(Venues),
                nameof(YourVisitSections)
            };

            Dependencies.AddRange(pipelinesToInclude);

            ProcessModules = new ModuleList
            {
                new ConcatDocuments(pipelinesToInclude),
                new FilterDocuments(Config.FromDocument((doc) =>
                    doc.Get<bool>("has-body-content", true) // we want to exclude shows that don't have any content
                )),
                new GenerateSitemap(Config.FromDocument((doc) =>
                    new SitemapItem(doc.GetLink(true))
                    {
                        LastModUtc = doc.GetPublishedDate()
                    }
                ))
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

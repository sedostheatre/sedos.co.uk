using Statiq.Common;
using Statiq.Core;
using Statiq.Web;

namespace Sedos.Pipelines
{
    public class Sitemap : Pipeline
    {
        public Sitemap()
        {
            Dependencies.Add(nameof(AboutSections));
            Dependencies.Add(nameof(AllShows));
            Dependencies.Add(nameof(News));            
            Dependencies.Add(nameof(Events));
            Dependencies.Add(nameof(Index));
            Dependencies.Add(nameof(MarkdownPages));
            Dependencies.Add(nameof(RegularEvents));
            Dependencies.Add(nameof(TopLevelPages));
            Dependencies.Add(nameof(Venues));
            Dependencies.Add(nameof(YourVisitSections));            

            ProcessModules = new ModuleList
            {
                new ConcatDocuments(nameof(AllShows)),
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

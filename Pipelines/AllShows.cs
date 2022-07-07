using Sedos.Helpers;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.Yaml;
using System.Linq;
using System.Threading.Tasks;

namespace Sedos.Pipelines
{
    public class AllShows : Pipeline
    {
        public AllShows()
        {
            Dependencies.AddRange(nameof(Venues));

            InputModules = new ModuleList
            {
                new ReadFiles("shows/*.md", "archive-shows/*.md")
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new SetMetadata("has-body-content", Config.FromDocument(d => d.ContentProvider.GetLength() > 0)),
                new SetMetadata("sections", Config.FromDocument((doc, ctx) =>
                    Task.WhenAll(doc.Get("sections", Enumerable.Empty<IDocument>())
                        .OrderBy(d => d.Get("order", 1))
                        .Select(d => MarkdownExtensions.ProcessMarkdownAsync(d, ctx))))),
                new SetMetadata("jsonLd", Config.FromDocument(doc => JsonLD.Show(doc))),
                MarkdownExtensions.MarkdownRenderer(),
                new RenderRazor()
                    .WithViewStart("Layout/_ShowViewStart.cshtml"),
                new ProcessShortcodes(),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                new FilterDocuments(Config.FromDocument((doc) =>
                    doc.Get<bool>("has-body-content")
                )),
                new WriteFiles()
            };
        }
    }
}

using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class MarkdownPages : Pipeline
    {
        public MarkdownPages()
        {
            Dependencies.AddRange(
                nameof(HeaderImages),
                nameof(TopLevelNav),
                nameof(Footer),
                nameof(News),
                nameof(UpcomingEvents),
                nameof(AllShows),
                nameof(RegularEvents));

            InputModules = new ModuleList
            {
                new ReadFiles("*.md", "groups/*.md")
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new SetMetadata("header-image", Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeHeaderImage(doc,ctx))),
                MarkdownExtensions.MarkdownRenderer(),
                new RenderRazor()
                    .WithViewStart(Config.FromDocument("view-start", "Layout/_PageViewStart.cshtml")),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

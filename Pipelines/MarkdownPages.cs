using Sedos.Helpers;
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
                nameof(Reviews),
                nameof(RegularEvents));

            InputModules = new ModuleList
            {
                new ReadFiles("{*,!index}.md", "groups/*.md")
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
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

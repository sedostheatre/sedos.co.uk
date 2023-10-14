using Sedos.Helpers;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class Index : Pipeline
    {
        public Index()
        {
            Dependencies.AddRange(
                nameof(AllShows),
                nameof(RegularEvents),
                nameof(UpcomingEvents),
                nameof(TopLevelNav),
                nameof(Footer),
                nameof(News));

            InputModules = new ModuleList
            {
                new ReadFiles("index.md"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                MarkdownExtensions.MarkdownRenderer("eventsText"),
                MarkdownExtensions.MarkdownRenderer("newsText"),
                MarkdownExtensions.MarkdownRenderer("carouselFooter"),
                MarkdownExtensions.MarkdownRenderer("supportUsMessage"),
                MarkdownExtensions.MarkdownRenderer("pageFooter"),
                new RenderRazor()
                    .WithViewStart("Layout/_IndexViewStart.cshtml"),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

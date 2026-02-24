using Sedos.Helpers;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class TopLevelPages : Pipeline
    {
        public TopLevelPages()
        {
            Dependencies.AddRange(
                nameof(AboutSections),
                nameof(AllShows),
                nameof(YourVisitSections),
                nameof(MarkdownPages), 
                nameof(SupportSections)
            );

            InputModules = new ModuleList
            {
                new ReadFiles(
                    "past-productions.cshtml",
                    "about.cshtml",
                    "your-visit.cshtml",
                    "all-shows.cshtml",
                    "support.cshtml"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new RenderRazor(),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

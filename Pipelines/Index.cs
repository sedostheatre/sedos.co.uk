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
                new ReadFiles("index.cshtml"),
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

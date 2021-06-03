using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class Venues : Pipeline
    {
        public Venues()
        {
            Dependencies.AddRange(
                nameof(TopLevelNav),
                nameof(Footer),
                nameof(HeaderImages));

            InputModules = new ModuleList
            {
                new ReadFiles("venues/*.md"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                MarkdownExtensions.MarkdownRenderer(),
                new RenderRazor()
                    .WithViewStart("Layout/_PageViewStart.cshtml"),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                 new WriteFiles()
            };
        }
    }
}

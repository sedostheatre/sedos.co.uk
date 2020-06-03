using Markdig.Extensions.Bootstrap;
using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class Venues : Pipeline
    {
        public Venues()
        {
            Dependencies.AddRange(nameof(FallbackHeaders), nameof(TopLevelNav), nameof(Footer));

            InputModules = new ModuleList
            {
                new ReadFiles("venues/*.md"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new RenderMarkdown()
                    .UseExtension<BootstrapExtension>()
                    .UseExtension<TargetLinkExtension>()
                    .UseExtensions(),
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

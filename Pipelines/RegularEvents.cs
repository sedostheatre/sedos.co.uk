using Markdig.Extensions.Bootstrap;
using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Yaml;
using System.Runtime.InteropServices;

namespace Sedos.Pipelines
{
    public class RegularEvents : Pipeline
    {
        public RegularEvents()
        {
            Dependencies.AddRange(nameof(Venues));

            InputModules = new ModuleList
            {
                new ReadFiles("regular-events/*.md")
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new RenderMarkdown()
                    .UseExtension<BootstrapExtension>()
                    .UseExtension<TargetLinkExtension>()
                    .UseExtensions(),
               new SetMetadata("header-image", Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeHeaderImage(doc,ctx))),
               new SetMetadata("image",  Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeImageFromMeta(doc, ctx, "image", 300, 300))),
               new SetMetadata("page-title", "RegularEvents"),
               new SetMetadata("background-override", "bg-purple"),
               new RenderRazor()
                    .WithViewStart("Layout/_EventViewStart.cshtml"),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

using Statiq.Common;
using Statiq.Core;

namespace Sedos.Pipelines
{
    public class RegularEvents : Pipeline
    {
        public RegularEvents()
        {
            OutputModules = new ModuleList
            { };
        }


//        Pipelines.Add("RegularEvents",
//    ReadFiles("regular-events/*.md"),
//    FrontMatter(Yaml()),
//    Markdown()
//        .UseExtension<Markdig.Extensions.Bootstrap.BootstrapExtension>()
//        .UseExtension<TargetLinkExtension>()
//        .UseExtensions(),
//    Meta("image", (doc, ctx) => CopyAndResizeImageFromMeta(doc, ctx, "image", 300, 300)),
//    Meta("header-image", CopyAndResizeHeaderImage),
//    Meta("page-title", "Regular Events"),
//    Meta("background-override", "bg-purple"),
//    Razor().WithViewStart("Layout/_EventViewStart.cshtml"),
//    WriteFiles(".html")
//);
    }
}

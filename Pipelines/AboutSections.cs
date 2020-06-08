using Statiq.Core;

namespace Sedos.Pipelines
{
    public class AboutSections : Pipeline
    {
        


        //        Pipelines.Add("AboutSections",
        //    ReadFiles("about/*.md"),
        //    FrontMatter(Yaml()),
        //    Markdown()
        //        .UseExtension<Markdig.Extensions.Bootstrap.BootstrapExtension>()
        //        .UseExtension<TargetLinkExtension>()
        //        .UseExtensions(),
        //    Meta("page-title", "About"),
        //    ForEach(
        //        Meta("image", (doc, ctx) => CopyAndResizeImageFromMeta(doc, ctx, "image", 600, 300))
        //    ),
        //    Razor().WithViewStart("Layout/_PageViewStart.cshtml"),
        //    Shortcodes(),
        //    WriteFiles(".html")
        //);
    }
}

using Sedos.Helpers;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class News : Pipeline
    {
        public News()
        {
            Dependencies.AddRange(nameof(TopLevelNav), nameof(Footer), nameof(HeaderImages));

            InputModules = new ModuleList
            {
                new ReadFiles("news/*.md"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                MarkdownExtensions.MarkdownRenderer(),
                new GenerateExcerpt().WithOuterHtml(false),
                new ProcessShortcodes(),

                new SetMetadata("image",  Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeImageFromMeta(doc, ctx, "image", 300, 300))),
                new SetMetadata("header-image", Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeHeaderImage(doc,ctx))),
                new SetMetadata("category", "news"),
                new SetMetadata("background-override", "bg-turquoise"),
                new SetDestination(".html"),
            };

            PostProcessModules = new ModuleList
            {
                new RenderRazor().WithViewStart("Layout/_NewsArticleViewStart.cshtml")
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

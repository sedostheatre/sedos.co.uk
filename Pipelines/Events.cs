using System;
using System.Linq;
using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Html;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class Events : Pipeline
    {
        public Events()
        {
            Dependencies.AddRange(nameof(TopLevelNav), nameof(Footer), nameof(HeaderImages), nameof(Venues));

            InputModules = new ModuleList
            {
                new ReadFiles("events/*.md"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new SetDestination(".html"),
                MarkdownExtensions.MarkdownRenderer(),
                new GenerateExcerpt().WithOuterHtml(false),
                new ProcessShortcodes(),

                new SetMetadata("image",  Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeImageFromMeta(doc, ctx, "image", 300, 300))),
                new SetMetadata("header-image", Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeHeaderImage(doc,ctx))),
                new SetMetadata("category", "events"),
                new SetMetadata("background-override", "bg-purple"),
                new SetMetadata("times", Config.FromDocument((doc, ctx) => doc.Get("times", Enumerable.Empty<IDocument>()).Select(t => t.Get<DateTime>("time")))),
                new RenderRazor().WithViewStart("Layout/_EventViewStart.cshtml"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

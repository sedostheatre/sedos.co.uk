using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Html;
using Statiq.Razor;
using Statiq.Yaml;
using Schema.NET;
using System;


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
                new SetMetadata("jsonLd",
                  new WebSite()
                  {
                    AlternateName = "An Alternative Name",
                    Name = "Your Site Name",
                    Url = new Uri("https://example.com")
                  }.ToHtmlEscapedString()),
                new RenderRazor().WithViewStart("Layout/_EventViewStart.cshtml"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

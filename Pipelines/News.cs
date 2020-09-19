﻿using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Html;
using Statiq.Razor;

namespace Sedos.Pipelines
{
    public class News : Pipeline
    {
        public News()
        {
            Dependencies.AddRange(nameof(TopLevelNav), nameof(Footer), nameof(HeaderImages), nameof(AllNews));

            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(AllNews)),
                MarkdownExtensions.MarkdownRenderer(),
                new GenerateExcerpt().WithOuterHtml(false),
                new ProcessShortcodes(),

                new SetMetadata("image",  Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeImageFromMeta(doc, ctx, "image", 300, 300))),
                new SetMetadata("header-image", Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeHeaderImage(doc,ctx))),
                new SetMetadata("category", "news"),
                new SetMetadata("background-override", "bg-turquoise"),
                new RenderRazor().WithViewStart("Layout/_NewsArticleViewStart.cshtml"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

﻿using Markdig.Extensions.Bootstrap;
using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class AboutSections : Pipeline
    {
        public AboutSections()
        {
            Dependencies.AddRange(nameof(HeaderImages), nameof(FallbackHeaders), nameof(TopLevelNav), nameof(Footer));

            InputModules = new ModuleList
            {
                new ReadFiles("about/*.md")
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new RenderMarkdown()
                    .UseExtension<BootstrapExtension>()
                    .UseExtension<TargetLinkExtension>()
                    .UseExtensions(),
                new SetMetadata("page-title", "About"),
                new SetMetadata("image",  Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeImageFromMeta(doc, ctx, "image", 600, 300))),
                new RenderRazor()
                    .WithViewStart("Layout/_PageViewStart.cshtml"),
                new ProcessShortcodes(),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

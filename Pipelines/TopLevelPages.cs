﻿using Sedos.Extensions;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class TopLevelPages : Pipeline
    {
        public TopLevelPages()
        {
            Dependencies.AddRange(nameof(AboutSections), nameof(AllShows), nameof(YourVisitSections));

            InputModules = new ModuleList
            {
                new ReadFiles("past-productions.cshtml", "about.cshtml", "your-visit.cshtml"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new SetMetadata("header-image", Config.FromDocument((doc, ctx) => HeaderImageExtensions.CopyAndResizeHeaderImage(doc,ctx))),
                new RenderRazor(),
                new SetDestination(".html"),
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

using Sedos.Extensions;
using SixLabors.ImageSharp.Processing;
using Statiq.Common;
using Statiq.Core;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class HeaderImages : Pipeline
    {
        public HeaderImages()
        {
            InputModules = new ModuleList
            {
                new     ReadFiles("header-images/*.yml"),
            };

            ProcessModules = new ModuleList
            {
                new ParseYaml(),
                new SetMetadata("image",
                  Config.FromDocument((doc, ctx) =>
                  HeaderImageExtensions.CopyAndResizeImageFromMeta(doc, ctx, "image-source", 1280, null, ResizeMode.Pad)))
            };
        }
    }
}

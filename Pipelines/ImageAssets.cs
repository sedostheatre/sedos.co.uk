using Statiq.Common;
using Statiq.Core;

namespace Sedos.Pipelines
{
    public class ImageAssets : Pipeline
    {
        public ImageAssets()
        {
            InputModules = new ModuleList
            {
                new ReadFiles(
                    "assets/**/*.jpg",
                    "assets/**/*.gif",
                    "assets/**/*.png",
                    "assets/**/*.pdf",
                    "assets/**/*.svg",
                    "assets/**/*.jpeg"
                )
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

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
                new ReadFiles("assets/**/*.*")
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

using Statiq.Common;
using Statiq.Core;
using Statiq.Images;

namespace Sedos.Pipelines
{
    public class FallbackHeaders : Pipeline
    {
        public FallbackHeaders()
        {
            InputModules = new ModuleList
            {
                new ReadFiles("assets/images/headers/fallback/*.*"),
            };

            ProcessModules = new ModuleList
            {
                new MutateImage().Resize(width: 1280, height: null)
            };

            OutputModules = new ModuleList
            {
                 new WriteFiles()
            };
        }
    }
}

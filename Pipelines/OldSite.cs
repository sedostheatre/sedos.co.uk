using Statiq.Common;
using Statiq.Core;

namespace Sedos.Pipelines
{
    public class OldSite : Pipeline
    {
        public OldSite()
        {
            InputModules = new ModuleList
            {
                new ReadFiles("old-site/**/*.*")
            };

            ProcessModules = new ModuleList
            {
                new SetDestination(Config.FromDocument(d => new NormalizedPath("old-site").GetRelativePath(d.Destination)))
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

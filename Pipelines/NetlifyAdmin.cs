using Statiq.Common;
using Statiq.Core;

namespace Sedos.Pipelines
{
    public class NetlifyAdmin : Pipeline
    {
        public NetlifyAdmin()
        {
            InputModules = new ModuleList
            {
                new ReadFiles("admin/**/*.*")
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

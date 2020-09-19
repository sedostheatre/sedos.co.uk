using Statiq.Common;
using Statiq.Core;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class TopLevelNav : Pipeline
    {
        public TopLevelNav()
        {
            InputModules = new ModuleList
            {
                new ReadFiles("top-level-nav.yml"),
            };

            ProcessModules = new ModuleList
            {
                new ParseYaml()
            };
        }
    }
}

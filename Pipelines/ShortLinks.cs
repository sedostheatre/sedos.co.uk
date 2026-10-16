using Statiq.Common;
using Statiq.Core;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class ShortLinks : Pipeline
    {
        public ShortLinks()
        {
            InputModules = new ModuleList
            {
                new ReadFiles("short-links.yml"),
            };

            ProcessModules = new ModuleList
            {
                new ParseYaml()
            };
        }
    }
}

using Statiq.Common;
using Statiq.Core;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class Footer : Pipeline
    {
        public Footer()
        {
            InputModules = new ModuleList
            {
                new ReadFiles("footer.yml"),
            };

            ProcessModules = new ModuleList
            {
                new ParseYaml()
            };
        }
    }
}

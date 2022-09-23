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
                new ReadFiles("header-images/*.yml"),
            };

            ProcessModules = new ModuleList
            {
                new ParseYaml()
            };
        }
    }
}

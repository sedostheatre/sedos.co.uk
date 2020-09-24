using Statiq.Common;
using Statiq.Core;
using Statiq.Sass;

namespace Sedos.Pipelines
{
    public class Sass : Pipeline
    {
        public Sass()
        {
            Isolated = true;

            InputModules = new ModuleList
            {
                new ReadFiles("assets/css/main.scss")
            };

            ProcessModules = new ModuleList
            {
                new CompileSass().WithCompactOutputStyle()
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}

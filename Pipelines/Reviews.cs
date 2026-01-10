using Sedos.Helpers;
using Statiq.Common;
using Statiq.Core;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    public class Reviews : Pipeline
    {
        public Reviews()
        {
            Dependencies.AddRange(
                nameof(HeaderImages),
                nameof(TopLevelNav),
                nameof(Footer));

            InputModules = new ModuleList
            {
                new ReadFiles("reviews/*.md"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                MarkdownExtensions.MarkdownRenderer(),
            };
        }
    }
}

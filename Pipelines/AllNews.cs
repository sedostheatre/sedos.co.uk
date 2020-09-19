using Statiq.Common;
using Statiq.Core;
using Statiq.Yaml;

namespace Sedos.Pipelines
{
    /// <summary>
    /// The AllNews pipeline preprocesses news articles to allow the rendering to refer to other news articles
    /// </summary>
    public class AllNews : Pipeline
    {
        public AllNews()
        {
            InputModules = new ModuleList
            {
                new ReadFiles("news/*.md"),
            };

            ProcessModules = new ModuleList
            {
                new ExtractFrontMatter(new ParseYaml()),
                new SetDestination(".html"),
            };
        }
    }
}

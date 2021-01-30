using Statiq.Common;
using Statiq.Core;
using System;
using System.Linq;

namespace Sedos.Pipelines
{
    public class UpcomingEvents : Pipeline
    {

        public UpcomingEvents()
        {
            Dependencies.AddRange(nameof(Events));

            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(Events)),
                new FilterDocuments(Config.FromDocument((doc, ctx) => doc.Get("times", Enumerable.Empty<IDocument>()).Any(time => time.Get<DateTime>("time") > DateTime.Now))),
                new OrderDocuments(Config.FromDocument((doc, ctx) => doc.Get("times", Enumerable.Empty<IDocument>())
                        .Select(time => time.Get<DateTime>("time"))
                        .First(time => time > DateTime.Now)))
            };
        }
    }
}

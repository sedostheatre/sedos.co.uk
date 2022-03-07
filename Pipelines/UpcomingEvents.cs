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
                new FilterDocuments(Config.FromDocument((doc, ctx) => doc.Get("times", Enumerable.Empty<DateTime>()).Any(time => time > DateTime.Now))),
                new OrderDocuments(Config.FromDocument((doc, ctx) => doc.Get("times", Enumerable.Empty<DateTime>())
                        .First(time => time > DateTime.Now)))
            };
        }
    }
}

using Statiq.Common;
using Statiq.Core;
using System.Collections.Generic;
using System.Linq;

namespace Sedos.Pipelines
{
    public class FutureShows : Pipeline
    {
        public FutureShows()
        {
            // Dependencies.Add(nameof(AllShows));

            ProcessModules = new ModuleList
            {
                new ConcatDocuments(Config.FromContext<IEnumerable<IDocument>>(ctx => ctx.Outputs.FromPipelines(ctx.Pipeline.GetAllDependencies(ctx).ToArray()))),
                // TODO actually filter in here
                
//Pipelines.Add("FutureShows",
//    ReadFiles("shows/*.md"),
//    FrontMatter(Yaml()),
//    WriteFiles(".html").OnlyMetadata(),
//    Meta("header-image", CopyAndResizeHeaderImage),
//    Meta("flyer", (doc, ctx) => CopyAndResizeImageFromMeta(doc, ctx, "flyer", null, 360)),
//    Meta("showtimes", (doc, ctx) => doc.Get("showtimes", Enumerable.Empty<IDocument>())),
//    Where((doc, ctx) => doc.Get<IEnumerable<IDocument>>("showtimes").Any(time => time.Get<DateTime>("time") > DateTime.Now)),
//    OrderBy((doc, ctx) => doc.Get<IEnumerable<IDocument>>("showtimes").Select(time => time.Get<DateTime>("time")).First())
//);
        };
        }
    }
}

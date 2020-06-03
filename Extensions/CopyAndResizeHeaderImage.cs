using Statiq.Common;
using Statiq.Core;
using Statiq.Images;
using System.Linq;
using System.Threading.Tasks;

namespace Sedos.Extensions
{
    public class HeaderImageExtensions
    {
        public static async Task<IDocument> CopyAndResizeHeaderImage(IDocument doc, IExecutionContext ctx)
        {
            return await CopyAndResizeImageFromMeta(doc, ctx, "header-image", 1280, null);
        }

        public static async Task<IDocument> CopyAndResizeImageFromMeta(IDocument doc, IExecutionContext ctx, string fieldName, int? width, int? height)
        {
            var fileName = doc.Get<string>(fieldName).TrimIfStartsWith("/");
            return string.IsNullOrWhiteSpace(fileName) ? null :
                await CopyAndResizeImageFromFile(doc, ctx, fileName, width, height);
        }

        public static async Task<IDocument> CopyAndResizeImageFromFile(IDocument doc, IExecutionContext ctx, string filename, int? width, int? height)
        {
            var documents = await ctx.ExecuteModulesAsync(
                new ModuleList
                {
                    new ReadFiles(filename),
                    new MutateImage().Resize(width: width, height:height),
                    new WriteFiles()
                },
                new IDocument[] { doc }
                );
            return documents.FirstOrDefault();
        }
    }
}

using Statiq.Common;
using Statiq.Markdown;
using System.Linq;
using System.Threading.Tasks;

namespace Sedos.Extensions
{
    public static class MarkdownExtensions
    {
        public static async Task<IDocument> ProcessMarkdownAsync(IDocument doc, IExecutionContext ctx)
        {
            var documents = await ctx.ExecuteModulesAsync(
                new IModule[] {
                    new RenderMarkdown("body")
                        .UseExtension<Markdig.Extensions.Bootstrap.BootstrapExtension>()
                        .UseExtension<TargetLinkExtension>()
                        .UseExtensions()},
                new IDocument[] { doc }
                );
            return documents.FirstOrDefault();
        }

        public static IModule MarkdownRenderer()
        {
            return new RenderMarkdown()
                 .UseExtension<Markdig.Extensions.Bootstrap.BootstrapExtension>()
                 .UseExtension<TargetLinkExtension>()
                 .UseExtensions();
        }

        public static IModule MarkdownRenderer(string metadataKey)
        {
            return new RenderMarkdown(metadataKey)
                 .UseExtension<Markdig.Extensions.Bootstrap.BootstrapExtension>()
                 .UseExtension<TargetLinkExtension>()
                 .UseExtensions();
        }
    }
}

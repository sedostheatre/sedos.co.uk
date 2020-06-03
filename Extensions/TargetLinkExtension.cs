using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Renderers.Html.Inlines;
using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;

namespace Sedos.Extensions
{
    public class TargetLinkExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipelineBuilder pipeline)
        {
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            var htmlRenderer = renderer as HtmlRenderer;
            if (htmlRenderer != null)
            {
                var inlineRenderer = htmlRenderer.ObjectRenderers.FindExact<LinkInlineRenderer>();
                if (inlineRenderer != null)
                {
                    inlineRenderer.TryWriters.Remove(TryLinkInlineRenderer);
                    inlineRenderer.TryWriters.Add(TryLinkInlineRenderer);
                }
            }
        }

        private bool TryLinkInlineRenderer(HtmlRenderer renderer, LinkInline linkInline)
        {
            if (linkInline.Url == null)
            {
                return false;
            }

            Uri uri;
            // Only process absolute Uri
            if (!Uri.TryCreate(linkInline.Url, UriKind.RelativeOrAbsolute, out uri) || !uri.IsAbsoluteUri)
            {
                return false;
            }
            RenderTargetAttribute(uri, renderer, linkInline);
            return false;
        }

        private void RenderTargetAttribute(Uri uri, HtmlRenderer renderer, LinkInline linkInline)
        {
            linkInline.SetAttributes(new HtmlAttributes() { Properties = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("target", "_blank") } });
        }
    }
}

using Statiq.Common;
using Schema.NET;
using System; // for Uri

namespace Sedos.Extensions
{
  public class JsonLD
  {
    public static string EventJsonLDFromDocument(Statiq.Common.IDocument doc)
    {
      return new PlayAction()
        {
            AlternateName = "An Alternative Name",
            Name = doc.Get<string>("title"), // doc.Get("title", ""),  // Get the Name prop from the docment
            Url = new Uri("https://example.com")
        }.ToHtmlEscapedString();
    }
  }
}

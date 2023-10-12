using Statiq.App;
using Statiq.Common;
using Statiq.Web;
using System.Globalization;
using System.Threading.Tasks;
using Sedos.Helpers;

namespace Minimal
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            return await Bootstrapper
                .Factory
                .CreateDefaultWithout(args, DefaultFeatures.Pipelines)
                .AddHostingCommands()
                .ConfigureFileSystem(fs => fs.InputPaths.Add("theme"))
                .AddSetting("title", Constants.Sedos)
                .AddSetting(Keys.Host, Constants.Domain)
                .AddSetting(Keys.DateTimeDisplayCulture, CultureInfo.InvariantCulture)
                .AddSetting(Keys.LinksUseHttps, true)
                .AddPipelines(typeof(Program).Assembly)
                .RunAsync();
        }
    }
}

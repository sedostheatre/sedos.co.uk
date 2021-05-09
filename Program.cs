using Statiq.App;
using Statiq.Common;
using Statiq.Web;
using System.Globalization;
using System.Threading.Tasks;

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
                .AddWeb()
                .ConfigureEngine(engine => engine.FileSystem.InputPaths.Add("theme"))
                .AddSetting("title", "Sedos")
                .AddSetting(Keys.Host, "sedos.co.uk")
                .AddSetting(Keys.DateTimeDisplayCulture, CultureInfo.InvariantCulture)
                .AddSetting(Keys.LinksUseHttps, true)
                .AddPipelines(typeof(Program).Assembly)
                .AddProcess(ProcessTiming.Initialization, "npm", "ci")
                .RunAsync();

        }
    }
}

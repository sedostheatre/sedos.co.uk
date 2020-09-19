using Statiq.App;
using Statiq.Common;
using Statiq.Web;
using System.Threading.Tasks;

namespace Minimal
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            return await Bootstrapper
                .Factory
                .CreateDefaultWithout(args, DefaultFeatures.Pipelines)
                .AddHostingCommands()
                .ConfigureEngine(engine => engine.FileSystem.InputPaths.Add("theme"))
                .AddSetting("title", "Sedos")
                .AddPipelines(typeof(Program).Assembly)
                .RunAsync();
        }
    }
}

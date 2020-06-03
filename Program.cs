using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace Minimal
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
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

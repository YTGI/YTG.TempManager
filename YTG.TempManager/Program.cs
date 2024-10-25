// --------------------------------------------------------------------------------
/*  Copyright © 2024, Yasgar Technology Group, Inc.
	Any unauthorized review, use, disclosure or distribution is prohibited.

	Purpose: Main Program Entry 

	Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using YTG.Framework.AppLogging;

namespace YTG.TempManager
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        /// <summary>
        /// Configure services for the application
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    if (OperatingSystem.IsWindows())
                    {
                        logging.AddEventLog();
                    }
                    logging.AddYTGAppLogger();
                }).ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Startup>();
                });





    }
}

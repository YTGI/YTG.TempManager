// --------------------------------------------------------------------------------
/*  Copyright © 2024, Yasgar Technology Group, Inc.
	Any unauthorized review, use, disclosure or distribution is prohibited.

	Purpose: Main Program Entry 

	Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

//using YTG.Framework.AppLogging;
using YTG.TempManager.Services;

namespace YTG.TempManager
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            IServiceProvider services = scope.ServiceProvider;

            services.GetRequiredService<IStartHere>().Start();


        }


        /// <summary>
        /// Configure services for the application
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            ConfigurationBuilder _configuration = new();
            IConfiguration _configurationBuilder = _configuration
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            IHostBuilder _host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    if (OperatingSystem.IsWindows())
                    {
                        logging.AddEventLog();
                    }
                    //logging.AddYTGAppLogger();
                }).ConfigureServices((hostContext, services) =>
                {
                    services.Configure<YTGAppSettings>(_configurationBuilder.GetSection("AppSettings"));
                    //services.Configure<YTGEventLoggerOptions>(_configurationBuilder.GetSection("Logging:YTGEventLogging"));
                    services.AddSingleton<IStartHere, StartHere>();
                    services.AddSingleton<ITFService, TFService>();
                });

            return _host;

        }
    }
}

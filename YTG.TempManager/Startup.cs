// --------------------------------------------------------------------------------
/*  Copyright © 2024, Yasgar Technology Group, Inc.
    Any unauthorized review, use, disclosure or distribution is prohibited.

    Purpose: Main Statup

    Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using YTG.Framework.AppLogging;
using YTG.TempManager.Services;

namespace YTG.TempManager
{

    /// <summary>
    /// Main Statup
    /// </summary>
    internal class Startup : IHostedService
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration, IServiceCollection services)
        {
            Configuration = configuration;
            Services = services;
        }

        /// <summary>
        /// Gets the IConfiguration DI object reference
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the DI Service Collection
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Called when this application starts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Get the appsettings values
            Services.Configure<YTGAppSettings>(Configuration.GetSection("AppSettings"));
            //Services.Configure<YTGEventLoggerOptions>(Configuration.GetSection("Logging:YTGEventLogging"));

            Services.AddSingleton<ITFService, TFService>();

            return Task.CompletedTask;

        }

        /// <summary>
        /// Nothing to do here
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

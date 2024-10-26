// --------------------------------------------------------------------------------
/*  Copyright © 2024, Yasgar Technology Group, Inc.
    Any unauthorized review, use, disclosure or distribution is prohibited.

    Purpose: Main logic for the application

    Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using YTG.Framework.AppLogging;
using YTG.TempManager.Services;

namespace YTG.TempManager
{
    internal class StartHere : IStartHere
    {


        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        //public StartHere()
        //{
        //    //service = tfService;
        //    //EventLogger = eventLogger;
        //    //AppLoggerOptions = loggerSettings.Value;
        //}
        //public StartHere(ITFService tfService, IEventLogger<StartHere> eventLogger, IOptions<YTGEventLoggerOptions> loggerSettings)
        //{
        //    service = tfService;
        //    EventLogger = eventLogger;
        //    AppLoggerOptions = loggerSettings.Value;
        //}
        public StartHere(ITFService tfService)
        {
            service = tfService;
            // EventLogger = eventLogger;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the DI reference to the ITFService implementation
        /// </summary>
        private ITFService service { get; }

        /// <summary>
        /// Gets the DI reference to the IEventLogger
        /// </summary>
        // private IEventLogger<StartHere> EventLogger { get; }

        /// <summary>
        /// Gets the AppLogging settings from appsettings.json
        /// </summary>
        //private YTGEventLoggerOptions AppLoggerOptions { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Main start point
        /// </summary>
        /// <returns></returns>
        public void Start()
        {
            try
            {
                service.CreateTempFolder();

                service.ArchiveTempFolder();
            }
            catch (Exception ex)
            {
                //EventLogger.LogError(ex, string.Empty, "Start", AppLoggerOptions.AppVersion);
            }
        }


        #endregion Public Methods

    }
}

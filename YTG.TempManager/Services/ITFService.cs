// --------------------------------------------------------------------------------
/*  Copyright © 2024, Yasgar Technology Group, Inc.
	Any unauthorized review, use, disclosure or distribution is prohibited.

	Purpose: Temp Folder Manager Service methods

	Description: 

*/
// --------------------------------------------------------------------------------

namespace YTG.TempManager.Services
{
    internal interface ITFService
    {

        /// <summary>
        /// Archive the temp folder to the archive folder under the temp folder
        /// </summary>
        /// <returns></returns>
        bool ArchiveTempFolder();

        /// <summary>
        /// Create the temp directory for today
        /// </summary>
        /// <returns></returns>
        bool CreateTempFolder();
    }
}
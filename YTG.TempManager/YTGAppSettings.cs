// --------------------------------------------------------------------------------
/*  Copyright © 2024, Yasgar Technology Group, Inc.
	Any unauthorized review, use, disclosure or distribution is prohibited.

	Purpose: Class for holding AppSetting values

	Description: 

*/
// --------------------------------------------------------------------------------

namespace YTG.TempManager
{
    internal class YTGAppSettings
    {

        public string? FolderRoot { get; set; }
        public string? ArchiveFolderRoot { get; set; }
        public int ArchiveLookbackDays { get; set; } = 14;
        public string? ApplicationUniqueId { get; set; }
        public string? ApplicationShortName { get; set; }
    }
}

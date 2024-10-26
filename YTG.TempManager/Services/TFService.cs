// --------------------------------------------------------------------------------
/*  Copyright © 2024, Yasgar Technology Group, Inc.
	Any unauthorized review, use, disclosure or distribution is prohibited.

	Purpose: Temp Folder Manager Service methods

	Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.Extensions.Options;

namespace YTG.TempManager.Services
{

    /// <summary>
    /// Temp Folder Manager Service methods
    /// </summary>
    internal class TFService : ITFService
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options"></param>
        public TFService(IOptions<YTGAppSettings> options)
        {
            AppSettings = options.Value;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the Appsettings valuse
        /// </summary>
        YTGAppSettings AppSettings { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Create the temp directory for today
        /// </summary>
        /// <returns></returns>
        public bool CreateTempFolder()
        {
            bool blnSuccess = false;
            try
            {
                string _folderName = DateTime.Now.ToString("yyyyMMdd");

                if (!(System.IO.Directory.Exists(AppSettings.ArchiveFolderRoot + _folderName)))
                {
                    System.IO.Directory.CreateDirectory(AppSettings.ArchiveFolderRoot + _folderName);
                    blnSuccess = true;
                }
            }
            catch (Exception)
            {
                return blnSuccess;
            }
            return blnSuccess;
        }

        /// <summary>
        /// Archive the temp folder to the archive folder under the temp folder
        /// </summary>
        /// <returns></returns>
        public bool ArchiveTempFolder()
        {
            bool blnSuccess = false;

            string _archiveFolderRoot = GetArchiveFolderRoot;
            if (!(System.IO.Directory.Exists(_archiveFolderRoot)))
            { System.IO.Directory.CreateDirectory(_archiveFolderRoot); }

            foreach (string directory in System.IO.Directory.GetDirectories(AppSettings.FolderRoot!))
            {
                DateTime datFolder = FolderToDate(directory);

                if ((datFolder < DateTime.Now.AddDays((AppSettings.ArchiveLookbackDays * -1)))
                    && (datFolder > DateTime.MinValue))
                {
                    if ((System.IO.Directory.GetFiles(directory).Count() == 0)
                        && (System.IO.Directory.GetDirectories(directory).Count() == 0))
                    {
                        // The folder has nothing in it
                        System.IO.Directory.Delete(directory);
                    }
                    string strFolderName = datFolder.ToString("yyyyMMdd");
                    if (!(System.IO.Directory.Exists(_archiveFolderRoot + strFolderName)))
                    {
                        System.IO.Directory.Move(directory, (_archiveFolderRoot + strFolderName));
                    }
                }
            }

            blnSuccess = true;

            return blnSuccess;

        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// The root folder for Archiving as defined in the appsettings.json file
        /// </summary>
        private string GetArchiveFolderRoot
        {
            get
            {
                string _archiveFolder = AppSettings.FolderRoot ?? "C:\\Temp";

                if (AppSettings.ArchiveFolderRoot != null)
                {
                    if (!_archiveFolder.EndsWith("\\"))
                    { _archiveFolder += "\\"; }
                }

                return _archiveFolder + AppSettings.ArchiveFolderRoot;

            }
        }

        /// <summary>
        /// Convert the folder to a date
        /// </summary>
        /// <param name="p_FolderName"></param>
        /// <returns></returns>
        private DateTime FolderToDate(string p_FolderName)
        {
            DateTime datReturn = DateTime.MinValue;

            int intFolderName;

            int intSlash = p_FolderName.LastIndexOf('\\');

            string strFolderName = p_FolderName.Substring(intSlash + 1, (p_FolderName.Length - (intSlash + 1)));

            if (strFolderName.Trim().Length == 8)
            {
                // See if the folder name is numeric
                if (int.TryParse(strFolderName, out intFolderName))
                {
                    string strDate = strFolderName.Substring(4, 2) + "-";
                    strDate += strFolderName.Substring(6, 2) + "-";
                    strDate += strFolderName.Substring(0, 4);
                    DateTime.TryParse(strDate, out datReturn);
                }
            }

            return datReturn;

        }

        #endregion Private Methods

    }
}

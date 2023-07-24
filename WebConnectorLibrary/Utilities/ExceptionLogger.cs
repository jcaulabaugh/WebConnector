/****************************************************************************************************************
 * File Name    : ExceptionLogger.cs
 * Description  : It is used for get/add methods.
 * Created By   : MCNi
 * Created Date : 11th May 2016
 ****************************************************************************************************************/

#region Namespace

using ConnectorLibrary.Utilities;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;

#endregion

namespace MCNiWebServiceApp.Utilities
{
    public class ExceptionLogger
    {
        #region Public Method

        /// <summary>
        /// Generic method for logging exception.
        /// </summary>
        /// <param name="exception">exception object</param>
        public static void LogException(Exception exception)
        {
            try
            {
                var currentDateTime = DateTime.Now;

                var errorLogFolderPath = ConfigurationManager.AppSettings[Common.ERROR_LOG_PATH];

                var currentDate = currentDateTime.ToShortDateString().Replace("/", "-");

                var dir = new DirectoryInfo(errorLogFolderPath);

                // If  directory  exist
                if (!dir.Exists)
                    dir.Create();

                // set current directory path
                Directory.SetCurrentDirectory(errorLogFolderPath);

                // set the file path
                var errorFilePath = (errorLogFolderPath + (@"ErrorLog_" + currentDate + ".txt"));

                // If file does not  exist
                if (!File.Exists(errorFilePath))
                    File.Create(errorFilePath).Close();

                // Open the error log txt file in append mode
                using (var sw = File.AppendText(errorFilePath))
                {
                    #region Append Text

                    sw.WriteLine("\r\nLog Entry : ");
                    sw.Write("-------------------------------------------------------------------------------");
                    sw.WriteLine();
                    sw.Write("DateTime:\t");
                    sw.Write(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine();
                    sw.WriteLine("Error Message:\t" + exception.Message);
                    sw.WriteLine();
                    sw.WriteLine("Exception Trace:\t" + exception);
                    if (exception.InnerException != null)
                    {
                        sw.WriteLine();
                        sw.WriteLine("Inner exception:\t" + exception);
                    }

                    sw.WriteLine();

                    sw.WriteLine();
                    sw.Write("-------------------------------------------------------------------------------");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();

                    #endregion Append Text

                    //StreamWriter sWriter = null;
                    //sWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\WindowServiceLogFile.txt", true);
                    //sWriter.WriteLine(DateTime.Now + exception.Message);
                    //sWriter.Flush();
                    //sWriter.Close();
                }
            }
            catch (Exception ex)
            {
                //do nothing
                Debug.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
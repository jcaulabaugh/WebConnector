using System;
using MCNiWebServiceApp.Utilities;


namespace ConnectorLibrary.Utilities
{
    public class LogSender
    {
        /// <summary>
        /// Method for sending the error log as an email attachment
        /// </summary>
        /// <param name="path"></param>
        /// <param name="date"></param>
        public static void SendErrorLog(string path, string date)
        {
            try
            {
                MAPI mapi = new MAPI();
                mapi.AddAttachment($"{ path }ErrorLog_{ date }.txt");
                mapi.AddRecipientTo("jca@routemanagement.com");
                mapi.SendMailPopup("MCNi Web Connector Error Record", "Attached is the error record.");
            
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                ActivityLog.activityListText("Error Recorded. Check Log.");
            }
        }
    }
}

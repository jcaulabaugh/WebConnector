using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorLibrary.Utilities
{
    /// <summary>
    /// This class is responsible for all hard coded values and other common functions.
    /// </summary>
    public static class Common
    {
        public enum RequestType
        {
            Sage50,
            Sage50Insert,
            Sage100,      
            Sage100Insert,
            MSGP, 
            MSGPInsert,
            Generic,
            GenericInsert
        }

        public enum MSGPTable
        {
            IV00101,
            IV00111,
            RM00101,
            IV00102,
            RM00301,
            TX00102,
            TX00101,
            TX00201,
            IV00105,
            RM00102,
            IV00108,
            IV40202,
            SY01200
        }

        //XML node paths for extracting table details
        public const string SAGE_50 = "Sage50";
        public const string SAGE_100 = "Sage100";
        public const string MSGP = "MSGP";
        public const string GENERIC = "GENERIC";
        public const string GENERIC_FILE_PATH = "GenericFilePath";

        //Sage sql commands
        public const string SAGE_COMMAND = "SageCommand";
        public const string SAGE_50_QUANTITY = "Sage50Quantity";

        //Error log
        public const string ERROR_LOG_PATH = "ErrorLogPath";

        //Activity log
        public const int ACTIVITY_LENGTH = 5000;
    }
}

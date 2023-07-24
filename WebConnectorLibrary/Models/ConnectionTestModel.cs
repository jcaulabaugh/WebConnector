namespace ConnectorLibrary.Models
{
    /// <summary>
    /// Check for authentication of username and password in the config forms
    /// </summary>
    public class ConnectionTestModel
    {
        public static bool MSGPConnectionStatus { get; set; }

        public static bool Sage100ConnectionStatus { get; set; }

        public static bool Sage50DatasourceConnectionStatus { get; set; }

        public static bool Sage50SDKConnectionStatus { get; set; }
    }
}

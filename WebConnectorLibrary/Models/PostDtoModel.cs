namespace ConnectorLibrary.Models
{
    /// <summary>
    /// This class is the send Model which contains
    /// all propertied needed to send back to the server
    /// </summary>
    public class PostDtoModel
    {
        public string Token { get; set; }

        public string Xml { get; set; }

        public string Status { get; set; }
    }
}

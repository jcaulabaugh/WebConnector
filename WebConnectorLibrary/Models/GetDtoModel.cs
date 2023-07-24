namespace ConnectorLibrary.Models
{
    /// <summary>
    /// This class is responsible for containing all properties
    /// needed for data transfer
    /// </summary>
    public class GetDtoModel
    {
        public bool Status { get; set; }

        public string Data { get; set; }

        public int Count { get; set; }

        public string XmlResponse { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace TaskXMLtoJSON.Model
{
    public class JSONModel
    {
        [JsonPropertyName("cdsCount")]
        public int CdsCount { get; set; }

        [JsonPropertyName("pricesSum")]
        public string PricesSum { get; set; }

        [JsonPropertyName("countries")]
        public string[] Countries { get; set; }

        [JsonPropertyName("minYear")]
        public string MinYear { get; set; }

        [JsonPropertyName("maxYear")]
        public string MaxYear { get; set; }
    }
}

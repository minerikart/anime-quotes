using System.Text.Json.Serialization;

namespace AnimeQuotes.Models
{
    public class QuoteModel
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

        [JsonPropertyName("anime")]
        public string Anime { get; set; }

        [JsonPropertyName("character")]
        public string Character { get; set; }

        [JsonPropertyName("quote")]
        public string Quote { get; set; }
        
    }
}

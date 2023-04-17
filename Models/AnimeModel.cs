using System.Text.Json.Serialization;

namespace AnimeQuotes.Models
{
    public class AnimeModel
    {
        
        [JsonPropertyName("MyArray")]
        public List<string> MyArray { get; set; }

    }

}

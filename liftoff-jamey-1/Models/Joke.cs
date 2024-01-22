using System.Text.Json.Serialization;

namespace liftoff_jamey_1.Models
{
    public class Joke
    {
        [JsonPropertyName("joke")]
        public string JokeText { get; set; }
    }
}

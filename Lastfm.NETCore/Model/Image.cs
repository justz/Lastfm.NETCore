using Newtonsoft.Json;

namespace Lastfm.NETCore.Model
{
    public class Image
    {
        [JsonProperty("#text")]
        public string Text { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }
}
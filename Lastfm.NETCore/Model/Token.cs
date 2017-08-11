using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lastfm.NETCore.Model
{
    public class Token
    {
        [JsonProperty("token")]
        public string Value { get; set; }
    }
}
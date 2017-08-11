using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lastfm.NETCore.Dto
{
    public class TokenDto
    {
        [JsonProperty("token")]
        public string Value { get; set; }
    }
}
using Newtonsoft.Json;

namespace Lastfm.NETCore.Dto
{
    public class TagDto
    {
        #region [Properties]

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        #endregion

        #region [Methods]

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
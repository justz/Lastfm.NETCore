using Newtonsoft.Json;

namespace Lastfm.NETCore.Model
{
    public class Image
    {
        #region [Properties]

        [JsonProperty("#text")]
        public string Text { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        #endregion

        #region [Methods]

        public override string ToString()
        {
            return Size;
        }

        #endregion
    }
}
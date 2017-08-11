using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lastfm.NETCore.Model
{
    public class SearchTrack : Track
    {
        #region [Properties]

        [JsonProperty("artist")]
        public new string Artist { get; set; }

        #endregion
    }
}
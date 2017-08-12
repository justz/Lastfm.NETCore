using Lastfm.NETCore.Contract;

namespace Lastfm.NETCore.Provider
{
    public class DefaultApiKeyProvider : IApiKeysProvider
    {
        #region [Ctor]

        public DefaultApiKeyProvider(string apiKey)
        {
            ApiKey = apiKey;
        }

        #endregion

        #region [Properties]

        public string ApiKey { get; }

        #endregion
    }
}
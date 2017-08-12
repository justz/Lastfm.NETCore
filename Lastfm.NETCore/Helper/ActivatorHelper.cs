using Lastfm.NETCore.Common;

namespace Lastfm.NETCore.Helper
{
    public static class ActivatorHelper
    {
        #region [Methods]

        public static void ThrowIfApiKeyProviderIsNull()
        {
            if (LastfmActivator.ApiKeysProvider == null)
                throw new RestClientException("You must instantiate ApiKeyProvider via LastfmActivator.Configure() before first api call");
        }

        #endregion
    }
}
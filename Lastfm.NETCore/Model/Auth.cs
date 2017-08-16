using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Dto;
using static Lastfm.NETCore.Helper.ActivatorHelper;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Model
{
    public sealed class Auth
    {
        public static async Task<Token> GetTokenAsync(string key)
        {
            ThrowIfApiKeyProviderIsNull();
            
            var url = new RequestUrlBuilder()
                .SetMethod("auth.getToken")
                .SetFormat()
                .SetApiKey(key)
                .Build();

            var token = await GetRequestAndMapAsync<TokenDto, Token>(url, null).ConfigureAwait(false);
            return token;
        }
    }
}
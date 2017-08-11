using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Model
{
    public sealed class Auth
    {
        public static async Task<Token> GetTokenAsync(string key)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("auth.getToken")
                .SetFormat()
                .SetApiKey(key)
                .Build();

            var token = await GetRequest<Token>(url, null);
            return token;
        }
    }
}
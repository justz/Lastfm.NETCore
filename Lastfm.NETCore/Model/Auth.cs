using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Helper;

namespace Lastfm.NETCore.Model
{
    public sealed class Auth
    {
        public static async Task<Token> GetToken(string key)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("auth.getToken")
                .SetFormat()
                .SetApiKey(key)
                .Build();

            var token = await RestClientHelper.GetRequest<Token>(url, null);
            return token;
        }
    }
}
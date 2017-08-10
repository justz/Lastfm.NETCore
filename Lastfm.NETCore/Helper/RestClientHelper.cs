using System;
using System.Threading.Tasks;
using Lastfm.NETCore.Common;
using Newtonsoft.Json;

namespace Lastfm.NETCore.Helper
{
    public class RestClientHelper
    {
        #region [Helpers]

        internal static Exception GetException(Exception ex, string content)
        {
            var result = ex ?? new RestClientException(ParseErrorResponse(content), null);
            return result;
        }

        internal static Task<T> ParseResponse<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        internal static ErrorResponse ParseErrorResponse(string response)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<ErrorResponse>(response);
                return result;
            }
            catch (JsonSerializationException ex)
            {
                throw new RestClientException(ex.Message, ex);
            }
            catch (JsonReaderException ex)
            {
                throw new RestClientException(ex.Message, ex);
            }
        }

        #endregion
    }
}
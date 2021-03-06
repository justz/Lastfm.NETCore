﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Lastfm.NETCore.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lastfm.NETCore.Helper
{
    public static class RestClientHelper
    {
        #region [Helpers]

        internal static async Task<T> GetRequestAsync<T>(string url, Func<JObject, JToken> keyParamsFunc)
        {
            using (var client = new HttpClient())
            {
                string content = null;
                
                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    response.EnsureSuccessStatusCode();

                    var tracks = await ParseResponseAsync<T>(keyParamsFunc?.Invoke(JObject.Parse(content))
                            .ToString() ?? JObject.Parse(content).ToString())
                        .ConfigureAwait(false);

                    await ThrowIfNullAsync(tracks, content).ConfigureAwait(false);
                    
                    return tracks;
                }
                catch (Exception ex)
                {
                    throw GetException(ex, content);
                }
            }
        }
        
        internal static async Task<TDestination> GetRequestAndMapAsync<TSource, TDestination>(string url, Func<JObject, JToken> keyParamsFunc)
        {
            using (var client = new HttpClient())
            {
                string content = null;
                
                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    response.EnsureSuccessStatusCode();

                    var res = await ParseResponseAsync<TSource>(keyParamsFunc?.Invoke(JObject.Parse(content))
                                                            .ToString() ?? JObject.Parse(content).ToString())
                        .ConfigureAwait(false);

                    await ThrowIfNullAsync(res, content).ConfigureAwait(false);

                    var data = Mapper.Map<TDestination>(res);
                    return data;
                }
                catch (Exception ex)
                {
                    throw GetException(ex, content);
                }
            }
        }

        internal static Exception GetException(Exception ex, string content)
        {
            var result = new RestClientException(ParseErrorResponse(content), ex);
            return result;
        }

        internal static Task<T> ParseResponseAsync<T>(string json)
        {
            return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
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
        
        private static async Task ThrowIfNullAsync(object obj, string content)
        {
            if (obj == null)
            {
                var error = await ParseResponseAsync<ErrorResponse>(content).ConfigureAwait(false);
                throw new RestClientException(error.Message);
            }
        }

        #endregion
    }
}
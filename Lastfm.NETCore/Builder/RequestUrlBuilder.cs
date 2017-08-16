using System.Text;

namespace Lastfm.NETCore.Builder
{
    internal sealed class RequestUrlBuilder
    {
        #region [Fields]

        private readonly StringBuilder _builder = new StringBuilder();

        #endregion

        #region [Ctor]

        internal RequestUrlBuilder()
        {
            _builder.Append(BaseUrl);
        }

        #endregion

        #region [Methods]

        public RequestUrlBuilder SetFormat(Format format = Format.Json)
        {
            _builder.Append($"&format={format.ToString().ToLowerInvariant()}");
            return this;
        }

        public RequestUrlBuilder SetAutoCorrect(bool autocorrect)
        {
            _builder.Append(autocorrect ? $"&autocorrect={1}" : $"&autocorrect={0}");
            return this;
        }

        public RequestUrlBuilder SetLimit(int limit)
        {
            _builder.Append($"&limit={limit}");
            return this;
        }

        public RequestUrlBuilder SetMethod(string method)
        {
            _builder.Append($"&method={method}");
            return this;
        }

        public RequestUrlBuilder SetApiKey(string key)
        {
            _builder.Append($"&api_key={key}");
            return this;
        }

        public RequestUrlBuilder SetMbid(string mbid)
        {
            _builder.Append($"&mbid={mbid}");
            return this;
        }

        public RequestUrlBuilder SetPage(int page)
        {
            _builder.Append($"&page={page}");
            return this;
        }

        public RequestUrlBuilder SetExtraMethod(string extra)
        {
            _builder.Append($"&{extra}");
            return this;
        }
        
        public RequestUrlBuilder SetExtraParams(params string[] extraParams)
        {
            foreach (var param in extraParams)
            {
                _builder.Append(param);
            }
            return this;
        }

        public string Build()
        {
            return _builder.ToString();
        }

        #endregion

        #region [Properties]

        internal const string BaseUrl = "http://ws.audioscrobbler.com/2.0/?";

        #endregion
    }

    internal enum Format
    {
        Json,
        Xml
    }
}
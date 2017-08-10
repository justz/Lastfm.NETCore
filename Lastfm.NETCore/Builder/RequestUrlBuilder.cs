using System.Text;

namespace Lastfm.NETCore.Builder
{
    public class RequestUrlBuilder
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public RequestUrlBuilder()
        {
            _builder.Append(BaseUrl);
        }

        public RequestUrlBuilder SetFormat(string format = "json")
        {
            _builder.Append($"&format={format}");
            return this;
        }

        public RequestUrlBuilder SetAutoCorrect(int autocorrect)
        {
            _builder.Append($"&autocorrect={autocorrect}");
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

        public const string BaseUrl = "http://ws.audioscrobbler.com/2.0/?";
    }
}
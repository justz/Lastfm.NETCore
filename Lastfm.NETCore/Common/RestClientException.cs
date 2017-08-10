using System;

namespace Lastfm.NETCore.Common
{
    public class RestClientException : Exception
    {
        public ErrorResponse ErrorResponse { get; }

        public RestClientException()
        {
        }

        public RestClientException(string message) : base(message)
        {
        }

        public RestClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RestClientException(ErrorResponse errorResponse, Exception innerException)
        {
            ErrorResponse = errorResponse;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Template.CrossCutting.ExceptionHandler.Extensions
{
    public class ApiException : Exception
    {
        public ApiException()
        { }

        public ApiException(string message,
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
                Exception innerException = null
                )
            : base(message, innerException)
        {
            StatusCode = statusCode;

        }

        public ApiException(string message)
            : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public ApiException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpStatusCode StatusCode { get; set; }
    }
}

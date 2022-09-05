using IBlog.Core.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Core.Results
{
    public class Result : IResult
    {
        public StatusCode StatusCode { get; }

        public string Message { get; }
        public Exception Exception { get; }

        public Result(StatusCode statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public Result(StatusCode statusCode, string message, Exception exception)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Exception = exception;
        }

        public static IResult FactoryResult(StatusCode statusCode, string message)
        {
            return new Result(statusCode, message);
        }
        public static IResult FactoryResult(StatusCode statusCode, string message, Exception exception)
        {
            return new Result(statusCode, message, exception);
        }
    }
}

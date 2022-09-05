using IBlog.Core.Results.ComplexTypes;

namespace IBlog.Core.Results
{
    public interface IResult
    {
        public StatusCode StatusCode { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}

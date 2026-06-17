
namespace Cryptomarket.SDK.Models
{
    /// <summary>
    /// Error Response from api
    /// </summary>
    public class ErrorResponse
    {
        public int? Status { get; init; }
        public ErrorBody? Error { get; init; }
        public string? Timestamp { get; init; }
        public string? Path { get; init; }
        public string? RequestId { get; init; }
        public string? Message { get; init; }

        public override string ToString()
        {
            return string.Format("ErrorResponse [error={0}, message={0}, path={0}, requestId={0}, status={0}, timestamp={0}]", Error, Message, Path, RequestId, Status, Timestamp);
        }
    }
}
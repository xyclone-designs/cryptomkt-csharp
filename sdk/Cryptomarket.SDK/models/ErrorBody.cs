
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Body of an error response
    /// </summary>
    public class ErrorBody(int code, string message, string? description)
    {
        public virtual int Code { get; set; } = code;
        public virtual string Message { get; set; } = message;
        public virtual string? Description { get; set; } = description;

        public override string ToString()
        {
            return string.Format("ErrorBody [code={0}, description={1}, message={2}]", Code, Description, Message);
        }
    }
}
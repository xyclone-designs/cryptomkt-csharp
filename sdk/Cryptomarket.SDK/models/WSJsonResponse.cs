
namespace CryptoMarket.SDK.Models
{
    /// <summary>
    /// Websocket response
    /// </summary>
    public class WSJsonResponse
    {
        public string? JsonRPC { get; set; }
        public int? Id { get; set; }
        public string? Method { get; set; }
        public string? Channel { get; set; }
        public string? TargetCurrency { get; set; }
        public ErrorBody? Error { get; set; }
        public object? Parameters { get; set; }
        public object? Result { get; set; }
        public object? Snapshot { get; set; }
        public object? Update { get; set; }
        public object? Data { get; set; }

        public override string ToString()
        {
            return string.Format(
                "WSJsonResponse [jsonrpc={0}, id={1}, method={2}, channel={3}, targetCurrency={4}, error={5}, parameters={6}, result={7}, snapshot={8}, update={9}, data={10}]",
                JsonRPC, 
                Id, 
                Method, 
                Channel, 
                TargetCurrency, 
                Error, 
                Parameters, 
                Result, 
                Snapshot, 
                Update, 
                Data);
        }
    }
}
using CryptoMarket.SDK.Exceptions;
using CryptoMarket.SDK.Models;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoMarket.SDK.Websocket
{
    public class WebSocketConnection : IDisposable
    {
        private ClientWebSocket websocket;
        private readonly IWSHandler handler;
        private readonly string url;
        private CancellationTokenSource cts;

        public WebSocketConnection(IWSHandler handler, string url)
        {
            this.handler = handler;
            this.url = url;
        }

        public virtual async Task RunAsync()
        {
            websocket = new ClientWebSocket();
            cts = new CancellationTokenSource();

            try
            {
                await websocket.ConnectAsync(new Uri(url), cts.Token);
                handler.OnConnect?.Invoke();
                await ReceiveLoopAsync();
            }
            catch (Exception ex) when (websocket.State != WebSocketState.Open)
            {
                handler.OnFailure?.Invoke(ex);
            }
        }

        private async Task ReceiveLoopAsync()
        {
            var buffer = new byte[4096];

            while (websocket.State == WebSocketState.Open)
            {
                try
                {
                    var sb = new StringBuilder();
                    WebSocketReceiveResult result;

                    do
                    {
                        result = await websocket.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            string reason = result.CloseStatusDescription ?? "";
                            handler.OnClose?.Invoke(reason);
                            await websocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                            return;
                        }

                        sb.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    }
                    while (!result.EndOfMessage);

                    string text = sb.ToString();
                    try
                    {
                        handler.Handle(text);
                    }
                    catch (CryptoMarketSDKException e)
                    {
                        Console.Error.WriteLine(e.ToString());
                    }
                }
                catch (OperationCanceledException)
                {
                    // Graceful shutdown via Dispose()
                    break;
                }
                catch (WebSocketException ex)
                {
                    handler.OnFailure?.Invoke(ex);
                    break;
                }
            }
        }

        public virtual void Send(string json)
        {
            if (websocket == null || websocket.State != WebSocketState.Open)
                throw new CryptoMarketSDKException("WebSocket is not connected.");

            byte[] bytes = Encoding.UTF8.GetBytes(json);
            websocket
                .SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None)
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// This socket asks the peer to close, then cleans up.
        /// </summary>
        public virtual void Dispose()
        {
            cts?.Cancel();

            if (websocket != null && websocket.State == WebSocketState.Open)
            {
                websocket
                    .CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", CancellationToken.None)
                    .GetAwaiter()
                    .GetResult();
            }

            websocket?.Dispose();
            cts?.Dispose();
        }
    }
}
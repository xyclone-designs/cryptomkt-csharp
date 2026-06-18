using Cryptomarket.SDK.Exceptions;

using System.Net.WebSockets;

namespace Cryptomarket.SDK.Websocket
{
    public class WebSocketConnection : WebSocketListener
    {
        WebSocket websocket;
        WSHandler handler;
        string url;
        public WebSocketConnection(WSHandler handler, string url)
        {
            this.handler = handler;
            this.url = url;
        }

        virtual void Run()
        {
            OkHttpClient client = new Builder().ReadTimeout(10, TimeUnit.SECONDS).Build();
            Request request = new Builder().Url(this.url).Build();
            websocket = client.NewWebSocket(request, this);
            client.Dispatcher().ExecutorService().Shutdown();
        }

        public override void OnOpen(WebSocket webSocket, Response response)
        {
            handler.GetOnConnect().Run();
        }

        public override void OnClosed(WebSocket webSocket, int code, string reason)
        {
            handler.GetOnClose().Accept(reason);
        }

        public override void OnMessage(WebSocket webSocket, string text)
        {
            try
            {
                handler.Handle(text);
            }
            catch (CryptomarketSDKException e)
            {
                e.PrintStackTrace();
            }
        }

        /// <summary>
        /// The peer ask for close to this socket
        /// </summary>
        public override void OnClosing(WebSocket webSocket, int code, string reason)
        {
            webSocket.Dispose(1000, null);
        }

        public override void OnFailure(WebSocket webSocket, Exception t, Response response)
        {
            handler.GetOnFailure().Accept(t);
        }

        public virtual void Send(string json)
        {
            websocket.Send(json);
        }

        /// <summary>
        /// this socket ask for close to the peer
        /// </summary>
        public virtual void Dispose()
        {
            websocket.Dispose(1000, null);
        }
    }
}
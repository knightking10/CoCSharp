using CoCSharp.Logic;
using CoCSharp.Network;
using CoCSharp.Server.API;
using System;
using System.Net.Sockets;

namespace CoCSharp.Server
{
    public class Client : IClient
    {
        #region Constructors
        public Client(Server server, Socket socket)
        {
            if (server == null)
                throw new ArgumentNullException(nameof(server));
            if (socket == null)
                throw new ArgumentNullException(nameof(socket));

            _server = server;
            _socket = socket;
            _networkManager = new NetworkManagerAsync(_socket, server.Settings);
            _networkManager.MessageReceived += OnMessage;
        }
        #endregion

        #region Fields & Properties
        public event EventHandler<DisconnectedEventArgs> Left;

        private bool _disposed;
        private readonly IServer _server;
        private readonly Socket _socket;
        private readonly NetworkManagerAsync _networkManager;

        public Socket Connection => _socket;
        public IServer Server => _server;

        public Level Level { get; set; }
        public byte[] SessionKey { get; set; }
        #endregion

        #region Methods
        public void Disconnect()
        {
            Dispose();
        }

        public void SendMessage(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            _networkManager.SendMessage(message);
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _networkManager.Dispose();
            _disposed = true;
        }

        private void OnMessage(object sender, MessageReceivedEventArgs e)
        {
            Server.Log.Info($"Received {e.Message.GetType().Name}");
            Server.Handler.Handle(this, e.Message);
        }
        #endregion
    }
}

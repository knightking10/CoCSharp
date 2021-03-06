﻿using CoCSharp.Logic;
using CoCSharp.Network;
using System;
using System.Net.Sockets;

namespace CoCSharp.Server.API
{
    /// <summary>
    /// Represents a remote client.
    /// </summary>
    public interface IClient : IDisposable
    {
        #region Fields & Properties
        /// <summary>
        /// Event raised when <see cref="IClient"/> leaves the server.
        /// </summary>
        event EventHandler<DisconnectedEventArgs> Left;

        /// <summary>
        /// Gets the <see cref="IServer"/> which owns this <see cref="IClient"/>.
        /// </summary>
        IServer Server { get; }

        /// <summary>
        /// Gets the <see cref="Socket"/> to which the <see cref="IClient"/> is connected to.
        /// </summary>
        Socket Connection { get; }

        /// <summary>
        /// Gets or sets the <see cref="Logic.Level"/> associated with the <see cref="IClient"/>.
        /// </summary>
        Level Level { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IClient"/>' session key.
        /// </summary>
        byte[] SessionKey { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Sends the specified <see cref="Message"/> to the <see cref="IClient"/> using the <see cref="Connection"/> <see cref="Socket"/>.
        /// </summary>
        /// <param name="message"><see cref="Message"/> to send.</param>
        void SendMessage(Message message);

        /// <summary>
        /// Disconnects <see cref="Connection"/>.
        /// </summary>
        void Disconnect();
        #endregion
    }
}

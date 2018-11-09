using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSERVER
{
    public class AsyncSocketServer : IDisposable
    {
        #region Fields

        /// <summary>
        /// max client 
        /// </summary>
        private int _maxClientCount;

        /// <summary>
        /// current clinet count
        /// </summary>
        private int _currentClientCount;

        /// <summary>
        /// server socket
        /// </summary>
        private Socket _serverSocket;

        /// <summary>
        /// session list
        /// </summary>
        private List<TcpClient> _clients;

        private bool disposed = false;

        #endregion

        #region Properties

        /// <summary>
        /// server state running or stop
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// server ip address
        /// </summary>
        public IPAddress ServerAddress { get; private set; }

        /// <summary>
        /// server port
        /// </summary>
        public int ServerPort { get; private set; }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="localIPAddress">服务器地址</param>
        /// <param name="listenPort">服务器端口</param>
        /// <param name="maxClient">连接限制</param>
        public AsyncSocketServer(IPAddress localIPAddress, int listenPort, int maxClient)
        {
            this.ServerAddress = localIPAddress;
            this.ServerPort = listenPort;
            this._maxClientCount = maxClient;

            _clients = new List<TcpClient>();
            _serverSocket = new Socket(localIPAddress.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// 异步Socket TCP服务器
        /// </summary>
        /// <param name="listenPort">监听的端口</param>
        public AsyncSocketServer(int listenPort) : this(IPAddress.Any, listenPort, 1024) { }


        /// <summary>
        /// 异步Socket TCP服务器
        /// </summary>
        /// <param name="localEP">监听的终结点</param>
        public AsyncSocketServer(IPEndPoint localEP) : this(localEP.Address, localEP.Port, 1024) { }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, 
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release 
        /// both managed and unmanaged resources; <c>false</c> 
        /// to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //try
                    //{
                    //    Stop();
                    //    if (_serverSock != null)
                    //    {
                    //        _serverSock = null;
                    //    }
                    //}
                    //catch (SocketException)
                    //{
                    //    //TODO
                    //    RaiseOtherException(null);
                    //}
                }
                disposed = true;
            }
        }
    }
}
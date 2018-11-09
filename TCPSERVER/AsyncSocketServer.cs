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
        private List<Socket> _clientsList;

        private byte[] Receivebuffer;

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

        #region 构造函数

        /// <summary>
        /// 异步Socket TCP服务器
        /// </summary>
        /// <param name="localIPAddress">服务器地址</param>
        /// <param name="listenPort">服务器端口</param>
        /// <param name="maxClient">连接限制</param>
        public AsyncSocketServer(IPAddress localIPAddress, int listenPort, int maxClient)
        {
            this.ServerAddress = localIPAddress;
            this.ServerPort = listenPort;
            this._maxClientCount = maxClient;

            _clientsList = new List<Socket>();
            _serverSocket = new Socket(localIPAddress.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// 异步Socket TCP服务器
        /// </summary>
        /// <param name="listenPort">监听的端口</param>
        public AsyncSocketServer(int listenPort) : this(IPAddress.Any, listenPort, 10) { }


        /// <summary>
        /// 异步Socket TCP服务器
        /// </summary>
        /// <param name="localEP">监听的终结点</param>
        public AsyncSocketServer(IPEndPoint localEP) : this(localEP.Address, localEP.Port, 10) { }

        #endregion

        #region 实现方法

        /// <summary>
        /// 启动服务器，默认最大连接数位10
        /// </summary>
        public void ServerStart()
        {
            if (!IsRunning)
            {
                _serverSocket.Bind(new IPEndPoint(this.ServerAddress, this.ServerPort));
                _serverSocket.Listen(10);
                _serverSocket.BeginAccept(new AsyncCallback(HandleAcceptClient), _serverSocket);
                IsRunning = true;
                Console.WriteLine($"服务器{ServerAddress.ToString()}已启动");
            }
        }

        /// <summary>
        /// 启动服务器，并设置最大连接数
        /// </summary>
        public void ServerStart(int backlog)
        {
            if (!IsRunning)
            {
                _serverSocket.Bind(new IPEndPoint(this.ServerAddress, this.ServerPort));
                _serverSocket.Listen(backlog);
                _serverSocket.BeginAccept(new AsyncCallback(HandleAcceptClient), _serverSocket);
                IsRunning = true;
            }
        }

        /// <summary>
        /// 关闭服务器
        /// </summary>
        public void ServerStop()
        {
            if(IsRunning)
            {
                _serverSocket.Close();
                IsRunning = false;
            }
        }

        public void HandleAcceptClient(IAsyncResult ar)
        {
           if(IsRunning)
           {              
                Socket _ServerSocket =(Socket)ar.AsyncState;  //服务端            
                Socket _ClientSocket = _ServerSocket.EndAccept(ar);//客户端

                if(_currentClientCount>=_maxClientCount)
                {
                    throw new Exception("连接数超过限制");
                }
                else
                {
                    _currentClientCount++; //客户端已连接     
                    _clientsList.Add(_ClientSocket);//加入列表
                    Console.WriteLine($"收到连接：{ _ClientSocket.RemoteEndPoint.ToString()}");

                    Receivebuffer = new byte[1024];
                    _ClientSocket.BeginReceive(Receivebuffer,0, Receivebuffer.Length,SocketFlags.None,new AsyncCallback(HandleDataReceive), _ClientSocket);
                }
                _ServerSocket.BeginAccept(new AsyncCallback(HandleAcceptClient), _ServerSocket);
           }
        }

        private void HandleDataReceive(IAsyncResult ar)
        {
            if (IsRunning)
            {
                Socket _ClientSocket = ar.AsyncState as Socket;
                int receivecount = _ClientSocket.EndReceive(ar);
                try
                {
                    if (receivecount == 0)
                    {
                        _currentClientCount--;
                        _clientsList.Remove(_ClientSocket);
                        _ClientSocket.Shutdown(SocketShutdown.Both);//关闭数据的接受和发送 
                        _ClientSocket.Close();//清理资源

                        //断开连接
                        //TO-DO
                        return;
                    }
                    Console.WriteLine($"收到数据：{ Encoding.ASCII.GetString(Receivebuffer)}");
                    if(Receivebuffer[0]==53)
                    {
                        Send(_ClientSocket,new byte[] {0,1,2,3,4,5 });
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _ClientSocket.BeginReceive(Receivebuffer, 0, Receivebuffer.Length, SocketFlags.None, new AsyncCallback(HandleDataReceive), _ClientSocket);
                }
            }
        }

        public void Send(Socket client, byte[] data)
        {
            if (!IsRunning)
                throw new InvalidProgramException("This TCP Scoket server has not been started.");

            if (client == null)
                throw new ArgumentNullException("client");

            if (data == null)
                throw new ArgumentNullException("data");
            client.BeginSend(data, 0, data.Length, SocketFlags.None,null, null);
        }
        #endregion


        #region Dispose
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
        #endregion
    }
}
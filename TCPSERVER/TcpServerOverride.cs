using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TcpServer.AsyncSocketServer;

namespace TCPSERVER
{
    public class TcpServerOverride : AsyncSocketServer
    {
        public TcpServerOverride(IPAddress _ip,int _port,int _max):base(_ip, _port, _max)
        {

        }

        public override void HandleSendDataCallback()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpServer.AsyncSocketServer;
using System.Net;
using System.Net.Sockets;

namespace TCPSERVER
{
    public partial class Form1 : Form
    {

        private AsyncSocketServer server;

        public Form1()
        {
            InitializeComponent();
            GetLocalIPaddress();
        }

        private void GetLocalIPaddress()
        {
            IPAddress[] iplist = Dns.GetHostAddresses(Dns.GetHostName());
            IPcomboBox.Items.Clear();
            foreach (IPAddress ip in iplist)
            {
                IPcomboBox.Items.Add(ip.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            server._ServerStart -= TcpServerStar;
            server._ClientConnected -= ClientConnected;
            server._ClientDisconnected -= ClientDisconnected;
            server._ReceiveData -= ReceiveData;
            server?.Dispose();

            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                server = new AsyncSocketServer(IPAddress.Parse(IPcomboBox.Text), int.Parse(PorttextBox.Text), 10);
                server._ServerStart += TcpServerStar;
                server._ClientConnected += ClientConnected;
                server._ClientDisconnected += ClientDisconnected;
                server._ReceiveData += ReceiveData;
                server.ServerStart();

                button2.Enabled = !server.IsRunning;
                button1.Enabled = server.IsRunning;
            }
            catch
            {
                server?.Dispose();
                button2.Enabled = true;
                button1.Enabled = false;
            }
        }

        private void ClientConnected(object sender, TcpServerClientConnectedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                ClientslistBox.Items.Clear();
                foreach (Socket s in server._clientsList)
                {
                    ClientslistBox.Items.Add(s.RemoteEndPoint.ToString());
                }
                LogtextBox.Text = LogtextBox.Text + $"\r\n{ DateTime.Now.ToString() + "Clients:" + e.Socket.RemoteEndPoint.ToString()}已连接";
            }));
        }

        private void TcpServerStar(object sender, TcpServerStartEventArgs e)
        {
            Invoke(new Action(() => { LogtextBox.Text = LogtextBox.Text + $"\r\n{ DateTime.Now.ToString() + "Server:" + e.Socket.LocalEndPoint.ToString()}已启动"; }));
        }

        private void ClientDisconnected(object sender, TcpServerClientDisconnectedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                ClientslistBox.Items.Clear();
                foreach (Socket s in server._clientsList)
                {
                    ClientslistBox.Items.Add(s.RemoteEndPoint.ToString());
                }
                LogtextBox.Text = LogtextBox.Text + $"\r\n{ DateTime.Now.ToString() + "Clients:" + e.Socket.RemoteEndPoint.ToString()}已断开";
            }));
        }

        private void ReceiveData(object sender, TcpServerReceiveDatadEventArgs e)
        {
            Invoke(new Action(() => { ReceivetextBox.Text = ReceivetextBox.Text + $"\r\n{ e.Socket.RemoteEndPoint.ToString() + "->收到:" + Encoding.ASCII.GetString(e.Data)}"; }));
        }
    }
}

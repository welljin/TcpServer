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
            server._SendData -= SendData;
            server?.Dispose();

            button2.Enabled = true;
            button1.Enabled = false;
            IPcomboBox.Enabled = true;
            PorttextBox.Enabled = true;
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
                server._SendData += SendData;
                server.ServerStart();

                button2.Enabled = !server.IsRunning;
                button1.Enabled = server.IsRunning;
                IPcomboBox.Enabled = !server.IsRunning;
                PorttextBox.Enabled = !server.IsRunning;
            }
            catch
            {
                server?.Dispose();
                button2.Enabled = true;
                button1.Enabled = false;
                IPcomboBox.Enabled = true;
                PorttextBox.Enabled = true;
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
                LogtextBox.Text = LogtextBox.Text + $"{ DateTime.Now.ToString() + "Clients:" + e.Socket.RemoteEndPoint.ToString()}已连接\r\n";
            }));
        }

        private void TcpServerStar(object sender, TcpServerStartEventArgs e)
        {
            Invoke(new Action(() => { LogtextBox.Text = LogtextBox.Text + $"{ DateTime.Now.ToString() + "Server:" + e.Socket.LocalEndPoint.ToString()}已启动\r\n"; }));
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
                LogtextBox.Text = LogtextBox.Text + $"{ DateTime.Now.ToString() + "Clients:" + e.Socket.RemoteEndPoint.ToString()}已断开\r\n";
            }));
        }

        private void ReceiveData(object sender, TcpServerReceiveDatadEventArgs e)
        {
            Invoke(new Action(() => { ReceivetextBox.Text = ReceivetextBox.Text + $"{ e.Socket.RemoteEndPoint.ToString() + "->收到:" + Encoding.ASCII.GetString(e.Data)}\r\n"; }));
        }

        private void SendData(object sender, TcpServerSendDatadEventArgs e)
        {
            Invoke(new Action(() => { LogtextBox.Text = LogtextBox.Text + $"{ e.Socket.LocalEndPoint.ToString() + "->发送:" + Encoding.ASCII.GetString(e.Data)}\r\n"; }));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (server._clientsList.Count > 0)
            {
                if (ClientslistBox.SelectedIndex != -1)
                {
                    server.HandleSendData(server._clientsList[ClientslistBox.SelectedIndex], Encoding.ASCII.GetBytes(this.SendtextBox.Text));
                }
                else
                {
                    MessageBox.Show("请选择客户端！");
                }
            }
            else
            {
                MessageBox.Show("无客户端连接！");
            }
        }
    }
}

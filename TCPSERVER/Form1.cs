using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPSERVER;
using System.Net;

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
            this.IPcomboBox.Items.Clear();
            foreach (IPAddress ip in iplist)
            {
                this.IPcomboBox.Items.Add(ip.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Dispose();
            button2.Enabled =true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server = new AsyncSocketServer(IPAddress.Parse(IPcomboBox.Text),int.Parse(PorttextBox.Text), 10);
            server.ServerStart();
            button2.Enabled = !server.IsRunning;
            button1.Enabled = server.IsRunning;
        }
    }
}

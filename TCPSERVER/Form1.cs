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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server = new AsyncSocketServer(IPAddress.Parse("127.0.0.1"), 502, 10);
            server.ServerStart();
        }
    }
}

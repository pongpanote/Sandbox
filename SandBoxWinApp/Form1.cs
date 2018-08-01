using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SandBoxWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ServerThread()
        {
            var udpClient = new UdpClient(8880);
            while (true)
            {
                var remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                var receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                var returnData = Encoding.ASCII.GetString(receiveBytes);
                listBox1.Items.Add(remoteIpEndPoint.Address + ":" + returnData);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thdUdpServer = new Thread(ServerThread);
            thdUdpServer.Start();
        }
    }
}

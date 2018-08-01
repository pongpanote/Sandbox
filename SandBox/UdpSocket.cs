using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SandBox
{
    public class UdpSocket
    {
        private readonly Socket m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int BUF_SIZE = 8 * 1024;
        private readonly State m_State = new State();
        private EndPoint m_EpFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback m_Recv;

        public class State
        {
            public byte[] Buffer = new byte[BUF_SIZE];
        }

        public void Server(string address, int port)
        {
            m_Socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            m_Socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
            Receive();
        }

        public void Client(string address, int port)
        {
            m_Socket.Connect(IPAddress.Parse(address), port);
            Receive();
        }

        public void Send(string text)
        {
            var data = Encoding.ASCII.GetBytes(text);
            m_Socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {
                //var so = (State)ar.AsyncState;
                var bytes = m_Socket.EndSend(ar);
                Console.WriteLine("SEND: {0}, {1}", bytes, text);
            }, m_State);
        }

        private void Receive()
        {
            m_Socket.BeginReceiveFrom(m_State.Buffer, 0, BUF_SIZE, SocketFlags.None, ref m_EpFrom, m_Recv = (ar) =>
            {
                var so = (State)ar.AsyncState;
                var bytes = m_Socket.EndReceiveFrom(ar, ref m_EpFrom);
                m_Socket.BeginReceiveFrom(so.Buffer, 0, BUF_SIZE, SocketFlags.None, ref m_EpFrom, m_Recv, so);
                Console.Write("RECV: {0}: {1}, {2}", m_EpFrom.ToString(), bytes, Encoding.ASCII.GetString(so.Buffer, 0, bytes));
            }, m_State);
        }
    }
}

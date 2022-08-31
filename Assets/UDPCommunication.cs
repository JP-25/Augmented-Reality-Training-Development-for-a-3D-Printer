using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using UnityEngine;

namespace DoS
{
    public class UDPCommunication : MonoBehaviour
    {
        public void Network()
        {
            byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes("<The packet of data>");

            //port and IP Data for socket client
            string IP = "192.168.1.19"; //192.168.1.14 in the lab
            int port = 80;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.SendTimeout = 1;

            client.SendTo(packetData, ep);
        }
    }
}

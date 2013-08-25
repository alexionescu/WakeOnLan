using System.Net;
using System.Net.Sockets;

namespace WakeOnLan {
    class Program {
        static void Main(string[] args) {
            WakeUp(new MACAddress(new byte[]{0x00, 0x00, 0x00, 0x00, 0x00, 0x00}));
        }

        public static void WakeUp(MACAddress mac) {
            byte[] packet = new byte[17 * 6];

            for (int i = 0; i < 6; i++) {
                packet[i] = 0xff;
            }

            for (int i = 1; i <= 16; i++) {
                for (int j = 0; j < 6; j++) {
                    packet[i * 6 + j] = mac[j];
                }
            }

            UdpClient client = new UdpClient();
            client.Connect(IPAddress.Broadcast, 0);
            client.Send(packet, packet.Length);
        }
    }
}

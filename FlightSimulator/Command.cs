using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace FlightSimulator
{
    class Command
    {
        private TcpClient client1;
        private const int portNum = 5400;
        private NetworkStream clientStream;

        public void connectClient()
        {
            bool done = false;

            TcpListener listener = new TcpListener(portNum);

            listener.Start();

            while (!done)
            {
                Console.Write("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                this.client1 = client;

                Console.WriteLine("Connection accepted.");
                NetworkStream ns = client.GetStream();
                this.clientStream = ns;
            }

            listener.Stop();

            return;
        }
        public void setInfo(string path)
        {
            byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString(path));

            try
            {
                this.clientStream.Write(byteTime, 0, byteTime.Length);
                this.clientStream.Close();
                this.client1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}

using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlightSimulator.Model
{
    public class Info : BaseNotify
    {
        private bool shouldStop;
        private float lon;
        private float lat;

        public Info()
        {
            shouldStop = false;
            lon = 0.0f;
            lat = 0.0f;
            openServer();
        }

        public float Lon
        {
            get { return lon; }
            set
            {
                lon = value;
            }
        }

        public float Lat
        {
            get { return lat; }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        private static string readLine(BinaryReader reader)
        {
            char[] buffer = new char[1024];
            int i = 0;
            char last = '\0';

            while (i < 1024 && last != '\n')
            {
                char input = reader.ReadChar();
                buffer[i] = input;
                last = buffer[i];
                i++;
            }

            return new string(buffer);
        }

        public void openServer()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.FlightServerIP),
                                                  Properties.Settings.Default.FlightInfoPort);
            TcpListener server = new TcpListener(ep);
            server.Start();

            Thread thread = new Thread(() => listenFlight(server));
            thread.Start();
        }

        private void listenFlight(TcpListener server)
        {
           
            TcpClient clientSocket = server.AcceptTcpClient();
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            DateTime start = DateTime.UtcNow;

            string inputLine;
            string[] splitStr;

            while (!shouldStop)
            {
                inputLine = readLine(reader);

                if (Convert.ToInt32((DateTime.UtcNow - start).TotalSeconds) < 90)
                {
                    continue;
                }

                splitStr = inputLine.Split(',');
                Lon = float.Parse(splitStr[0]);
                Lat = float.Parse(splitStr[1]);
                Console.WriteLine("Lon {0} Lat {1}", Lon, Lat);
                //Thread.Sleep(250);
            }

            clientSocket.Close();
            server.Stop();

        }

        //private TcpClient client1;
        //private const int portNum = 5400;
        //private NetworkStream clientStream;
        //private IPAddress myIP = new IPAddress(127,0,0,1);

        //public void connectClient()
        //{
        //    bool done = false;

        //    TcpListener listener = new TcpListener(,portNum);

        //    listener.Start();

        //    while (!done)
        //    {
        //        Console.Write("Waiting for connection...");
        //        TcpClient client = listener.AcceptTcpClient();
        //        this.client1 = client;

        //        Console.WriteLine("Connection accepted.");
        //        NetworkStream ns = client.GetStream();
        //        this.clientStream = ns;
        //    }

        //    listener.Stop();

        //    return;
        //}


    }

}




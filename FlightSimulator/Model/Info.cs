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
using FlightSimulator.ViewModels;


namespace FlightSimulator.Model
{
    public class Info 
    {
        private bool shouldStop;
        private float lon;
        private float lat;

        public Info()
        {
            shouldStop = false;
            lon = 0.0f;
            lat = 0.0f;
            
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
                
            }
        }

        private static string readLine(BinaryReader reader)
        {
            char[] buffer = new char[1024];
            int i = 0;
            char end = '\0';

            while (i < 1024 && end != '\n')
            {
                char input = reader.ReadChar();
                buffer[i] = input;
                end = buffer[i];
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
            TcpClient clientSocket = server.AcceptTcpClient();

            Thread thread = new Thread(() => listenFlight(server,clientSocket));
            thread.Start();
        }

        private void listenFlight(TcpListener server, TcpClient clientSocket)
        {
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
                FlightBoardViewModel.Instance.Lon = float.Parse(splitStr[0]);
                FlightBoardViewModel.Instance.Lat = float.Parse(splitStr[1]);
              //  Console.WriteLine("lon " + FlightBoardViewModel.Instance.Lon + "lat " + FlightBoardViewModel.Instance.Lat);
                //Thread.Sleep(250);
            }

            clientSocket.Close();
            server.Stop();
        }
    }

}




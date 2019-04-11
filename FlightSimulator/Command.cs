using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;


using System.Net;
using System.IO;

namespace FlightSimulator
{
    public class Command {

        public Dictionary<string, double> pathRead = new Dictionary<string, double>();
        public Dictionary<string, string> SimulatorPath = new Dictionary<string, string>();
        NetworkStream ns;
        TcpClient client;

        public Command()
        {
            this.SetTheMap();
        }
        public void connectServer()
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
            this.client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
            this.ns = client.GetStream();


            
            {


            }
            }
        
        


        private void  SetTheMap()
        {
            
            this.SimulatorPath.Add("aileron", "/controls/flight/aileron");
            this.SimulatorPath.Add("elevator", "/controls/flight/elevator");
            this.SimulatorPath.Add("rudder", "/controls/flight/rudder");
            this.SimulatorPath.Add("throttle", "/controls/engines/current-engine/throttle");
        }

        public void setData()
        {

            this.pathRead.Add("/instrumentation/airspeed-indicator/indicated-speed-kt", 0);
            this.pathRead.Add("/instrumentation/altimeter/indicated-altitude-ft", 0);
            this.pathRead.Add("/instrumentation/altimeter/pressure-alt-ft", 0);
            this.pathRead.Add("/instrumentation/attitude-indicator/indicated-pitch-deg", 0);
            this.pathRead.Add("/instrumentation/attitude-indicator/indicated-roll-deg", 0);
            this.pathRead.Add("/instrumentation/attitude-indicator/internal-pitch-deg", 0);
            this.pathRead.Add("/instrumentation/attitude-indicator/internal-roll-deg", 0);
            this.pathRead.Add("/instrumentation/encoder/indicated-altitude-ft", 0);
            this.pathRead.Add("/instrumentation/encoder/pressure-alt-ft", 0);
            this.pathRead.Add("/instrumentation/gps/indicated-altitude-ft", 0);
            this.pathRead.Add("/instrumentation/gps/indicated-ground-speed-kt", 0);
            this.pathRead.Add("/instrumentation/gps/indicated-vertical-speed", 0);
            this.pathRead.Add("/instrumentation/heading-indicator/indicated-heading-deg", 0);
            this.pathRead.Add("/instrumentation/magnetic-compass/indicated-heading-deg", 0);
            this.pathRead.Add("/instrumentation/slip-skid-ball/indicated-slip-skid", 0);
            this.pathRead.Add("/instrumentation/turn-indicator/indicated-turn-rate", 0);
            this.pathRead.Add("/instrumentation/vertical-speed-indicator/indicated-speed-fpm", 0);
            this.pathRead.Add("/controls/flight/aileron", 0);
            this.pathRead.Add("/controls/flight/elevator", 0);
            this.pathRead.Add("/controls/flight/rudder", 0);
            this.pathRead.Add("/controls/flight/flaps", 0);
            this.pathRead.Add("/controls/engines/current-engine/throttle", 0);
            this.pathRead.Add("/engines/engine/rpm", 0);
        }

        public void setDict(List<double> vector1)
        {
            this.pathRead["/instrumentation/airspeed-indicator/indicated-speed-kt"] = vector1[0];
            this.pathRead["/instrumentation/altimeter/indicated-altitude-ft"] = vector1[1];
            this.pathRead["/instrumentation/altimeter/pressure-alt-ft"] = vector1[2];
            this.pathRead["/instrumentation/attitude-indicator/indicated-pitch-deg"] = vector1[3];
            this.pathRead["/instrumentation/attitude-indicator/indicated-roll-deg"] = vector1[4];
            this.pathRead["/instrumentation/attitude-indicator/internal-pitch-deg"] = vector1[5];
            this.pathRead["/instrumentation/attitude-indicator/internal-roll-deg"] = vector1[6];
            this.pathRead["/instrumentation/encoder/indicated-altitude-ft"] = vector1[7];
            this.pathRead["/instrumentation/encoder/pressure-alt-ft"] = vector1[8];
            this.pathRead["/instrumentation/gps/indicated-altitude-ft"] = vector1[9];
            this.pathRead["/instrumentation/gps/indicated-ground-speed-kt"] = vector1[10];
            this.pathRead["/instrumentation/gps/indicated-vertical-speed"] = vector1[11];
            this.pathRead["/instrumentation/heading-indicator/indicated-heading-deg"] = vector1[12];
            this.pathRead["/instrumentation/magnetic-compass/indicated-heading-deg"] = vector1[13];
            this.pathRead["/instrumentation/slip-skid-ball/indicated-slip-skid"] = vector1[14];
            this.pathRead["/instrumentation/turn-indicator/indicated-turn-rate"] = vector1[15];
            this.pathRead["/instrumentation/vertical-speed-indicator/indicated-speed-fpm"] = vector1[16];
            this.pathRead["/controls/flight/aileron"] = vector1[17];
            this.pathRead["/controls/flight/elevator"] = vector1[18];
            this.pathRead["/controls/flight/rudder"] = vector1[19];
            this.pathRead["/controls/flight/flaps"] = vector1[20];
            this.pathRead["/controls/engines/current-engine/throttle"] = vector1[21];
            this.pathRead["/engines/engine/rpm"] = vector1[22];
        }



        public void setInfo(List<string> path)
        {
            /*using (NetworkStream stream = new NetworkStream(client.Client, false))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                string goTo = "set ";
                goTo += this.SimulatorPath[path[0]];
                goTo += " ";
                goTo += path[1];
                goTo += "\r\n";

                byte[] data = System.Text.Encoding.ASCII.GetBytes(goTo);
                Console.WriteLine(goTo);
                writer.Write(data);
                writer.Flush();
            }*/

            string goTo = "set ";
            goTo += this.SimulatorPath[path[0]];
            goTo += " ";
            goTo += path[1];
            goTo += "\r\n";
            Console.WriteLine(goTo);
            byte[] byteTime = System.Text.Encoding.ASCII.GetBytes(goTo.ToString());
            this.ns.Write(byteTime, 0, byteTime.Length);

        }

        public void setFromAuto(List<List<string>> s)
        {
                if (s.Count != 0)
                {
                    using (NetworkStream stream = new NetworkStream(this.client.Client, false))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        while (s.Count != 0)
                        {
                        List<string> temp = s[0];
                        temp.Add("\r\n");
                        s.RemoveAt(0);
                        string path =this.Concat(temp);
                        
                        byte[] data = System.Text.Encoding.ASCII.GetBytes(path);
                        Console.WriteLine(path);
                        writer.Write(data);
                        writer.Flush();
                        Thread.Sleep(2000);
                        }
                    }
                }
               
            }


        private string Concat(List<String> thePath)
        {
            string r = "";
            for (int i = 0; i < thePath.Count; i++)
            {
                r += thePath[i];
            }
            return r;
        }

    }

    }




    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace FlightSimulator
{ 


public class info
{
    
    public Dictionary<string, double> pathRead = new Dictionary<string, double>();

    public void connectServer()
    {
        try
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");


            NetworkStream ns = client.GetStream();

            byte[] bytes = new byte[1024];
            int bytesRead = ns.Read(bytes, 0, bytes.Length);

            Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRead));

            client.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return;

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

    }
}

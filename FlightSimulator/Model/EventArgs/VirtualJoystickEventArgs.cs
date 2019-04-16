using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.EventArgs
{
    public class VirtualJoystickEventArgs
    {
        private double aileron;
        private double elevator;

        public VirtualJoystickEventArgs()
        {
            aileron = 0;
            elevator = 0;
        }
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                List<string> arg = new List<string>();
                aileron = value;
                if (aileron < -1)
                {
                    aileron = -1;
                }
                else if (aileron > 1)
                {
                    aileron = 1;
                }
                arg.Add("aileron");
                arg.Add(aileron.ToString());
                if (SingeltonCommand.Instance.GetDidConnect())
                {
                    SingeltonCommand.Instance.setInfo(arg);
                }

            }
        }
        public double Elevator
        {

            get
            {
                return elevator;
            }
            set
            {
                List<string> arg = new List<string>();
                elevator = value;
                if (elevator < -1)
                {
                    elevator = -1;
                }
                else if (elevator > 1)
                {
                    elevator = 1;
                }
                arg.Add("elevator");
                arg.Add(elevator.ToString());
                if (SingeltonCommand.Instance.GetDidConnect())
                {
                    SingeltonCommand.Instance.setInfo(arg);
                }

            }
        }
    }
}

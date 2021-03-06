﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.ViewModels
{
    /*this class is the view model of the joystick
     and evry property do the same - it pass the data he gets from the view and pass it to the server*/
    public class JoystickVM
    {
        private double aileron;
        private double elevator;

        public JoystickVM()
        {
            aileron = 0;
            elevator = 0;
        }
        /*this is the property of the aileron */
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
        /*this is the property of the elevator */
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

        /*this is the property of the rudder */
        public string Rudder
        {
            
            set
            {


                List<String> path = new List<string> ();
                path.Add("rudder");
                path.Add(value);
                if (SingeltonCommand.Instance.GetDidConnect())
                {
                    SingeltonCommand.Instance.setInfo(path);
                }
               
               
                
            }
        }
        /*this is the property of the throttle */
        public string Throttle
        {
           
            set {
                List<String> path = new List<string>();
                path.Add("throttle");
                path.Add(value);
                if (SingeltonCommand.Instance.GetDidConnect())
                {
                    SingeltonCommand.Instance.setInfo(path);
                }

            }
        }



        

      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.ViewModels
{
    public class JoystickVM
    {

        private Command command;
       

        public JoystickVM()
        {
            this.command = new Command();
        }



        public string Aileron
        {
            
            set
            {
                
            }
        }
        public string Elevator
        {
           
            set
            {
                
            }
        }
        public string Rudder
        {
            
            set
            {


                List<String> path = new List<string> ();
                path.Add("rudder");
                path.Add(value);
                //this.command.setInfo(path);
                
            }
        }
        public string Throttle
        {
           
            set {
                List<String> path = new List<string>();
                path.Add("throttle");
                path.Add(value);
                //this.command.setInfo(path);

            }
        }

        

      
    }
}

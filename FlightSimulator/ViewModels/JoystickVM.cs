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
        private string elevator;
        private string rudder;
        private string throttle;
        private string aileron;



        public string Aileron
        {
            
            set
            {
                this.aileron = value;
                //this.command.setInfo(this.aileron);
            }
        }
        public string Elevator
        {
           
            set
            {
                this.elevator = value;
                //this.command.setInfo(this.elevator);
            }
        }
        public string Rudder
        {
            
            set
            {


                List<String> path = new List<string> ();
                path.Add("rudder");
                path.Add(value);
                Console.WriteLine("im rudder");
                this.rudder = value;
                Console.WriteLine(value);
                this.command.setInfo(path);
                
            }
        }
        public string Throttle
        {
           
            set {
                
                // this.throttle = value;
                //this.command.setInfo(this.throttle);
            }
        }

        public void SaveSettings1(RoutedPropertyChangedEventArgs<double> e)
        {
            this.command = new Command();
            this.command.connectServer();
            string a = e.NewValue.ToString();
            this.Rudder = a;
           
        }

      
    }
}

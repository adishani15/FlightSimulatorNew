using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoVM
    {
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                Console.WriteLine("adi");
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnClick()));
            }
            set
            {
                Console.WriteLine("adi");
            }
        }
        private void OnClick()
        {
            /*m_flightManager.Connect();
            IsDisconnected = false; // Setting that the server is
            connected*/
        }
    }
}

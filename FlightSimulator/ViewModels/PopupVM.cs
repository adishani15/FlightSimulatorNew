using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views;
namespace FlightSimulator.ViewModels
{
    class PopupVM
    {
            private ICommand _settingsCommand;
            public ICommand SettingsCommand
            {
                get
                {
                    Console.WriteLine("adi");
                    return _settingsCommand ?? (_settingsCommand =
                    new CommandHandler(() => OnClick()));
                }
                set
                {
                    Console.WriteLine("adi");
                }
            }
            private void OnClick()
            {
            PopupSettings p = new PopupSettings();
            p.ShowDialog();
                /*m_flightManager.Connect();
                IsDisconnected = false; // Setting that the server is
                connected*/
            }
        }
    }


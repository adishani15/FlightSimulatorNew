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
        // ICommand for the popup of the settings.
        private ICommand _settingsCommand;
        // ICommand for the disconnect button.
        private ICommand closeCommand;
        private bool alredyConnect;

        public PopupVM()
        {
            this.alredyConnect = false;
        }

        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand =
                new CommandHandler(() => OnClick()));
            }
            set
            {

            }
        }

        public ICommand DisConnectClick
        {
            get {
               
                 return closeCommand ?? (closeCommand =
                new CommandHandler(() => close()));

            }
        }
            

        private void OnClick()
        {
            PopupSettings p = new PopupSettings();
            // show the popup window
             p.ShowDialog();
        }
        
        // ICommand for the connect to listen to the flight
        private ICommand _listenCommand;
        public ICommand ListenCommand
        {
            get
            {
                return _listenCommand ?? (_listenCommand =
                new CommandHandler(() => ToConnect()));
            }
            set
            {

            }
        }
        private void ToConnect()
        {
            // only if not connected- connect.
            if (!this.alredyConnect)
            {
                this.open();
                this.alredyConnect = true;
            }
            else
            {
                return;
            }

        }

        // open the connection- the Info and the command
        private void open()
        {
            SingeltonInfo.Instance.openServer();
            SingeltonCommand.Instance.connectServer();
        }

        // close the connection.
        private void close()
        {
            if (SingeltonCommand.Instance.GetDidConnect())
            {
                SingeltonCommand.Instance.close();
                SingeltonInfo.Instance.close();
            }
        }
    }

}



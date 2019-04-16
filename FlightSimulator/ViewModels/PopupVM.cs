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
                Console.WriteLine("_----------------------");
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
             p.ShowDialog();
        }
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

        private void open()
        {
            SingeltonInfo.Instance.openServer();
            SingeltonCommand.Instance.connectServer();
        }

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



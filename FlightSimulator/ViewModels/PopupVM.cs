﻿using System;
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
                Console.WriteLine("_----------------------");
                return _settingsCommand ?? (_settingsCommand =
                new CommandHandler(() => OnClick()));
            }
            set
            {

            }
        }
        private void OnClick()
        {
            Console.WriteLine("*************************************");
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
            SingeltonInfo.Instance.openServer();
            SingeltonCommand.Instance.connectServer();
        }
    }
}



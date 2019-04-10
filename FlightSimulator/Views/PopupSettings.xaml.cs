﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Model;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for PopupSettings.xaml
    /// </summary>
    public partial class PopupSettings : Window
    {
        public PopupSettings()
        {
            InitializeComponent();
            this.DataContext = new SettingsWindowViewModel(new ApplicationSettingsModel());
           
        }
    }
}

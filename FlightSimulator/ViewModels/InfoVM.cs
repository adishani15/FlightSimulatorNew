using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class InfoVM :BaseNotify
    {
        private Info model;
        public InfoVM()
        {
            this.model = new Info();
        }
    }
}

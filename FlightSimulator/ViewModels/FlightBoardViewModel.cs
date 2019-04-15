using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
       // FlightBoard f = new FlightBoard();
        public FlightBoardViewModel()
        {
            Console.WriteLine("in constructor!");
           
        }


        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }
    }
}

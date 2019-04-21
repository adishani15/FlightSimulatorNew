using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator
{
    // the command should be singelton- only one connection.
    public class SingeltonCommand
    {
        private static Command m_Instance = null;
        public static Command Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Command();
                }
                return m_Instance;
            }
        }
    }
}


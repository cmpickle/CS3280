using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Flight object cointains all information about a specific flight
    /// </summary>
    class clsFlight
    {
        /// <summary>
        /// The flight's ID
        /// </summary>
        public int FlightID { get; set; }

        /// <summary>
        /// The flight's number
        /// </summary>
        public int FlightNum { get; set; }

        /// <summary>
        /// The flight's type
        /// </summary>
        public String FlightType { get; set; }
        
        /// <summary>
        /// Defines the string version of the flight class
        /// </summary>
        /// <returns>String for flight</returns>
        public override String ToString()
        {
            return FlightNum + " " + FlightType;
        }
    }
}

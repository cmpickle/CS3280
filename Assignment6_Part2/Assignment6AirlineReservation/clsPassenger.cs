using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Contains all information about passenger objects
    /// </summary>
    class clsPassenger
    {
        /// <summary>
        /// The passenger's ID
        /// </summary>
        public int PassengerID { get; set; }

        /// <summary>
        /// The passenger's first name
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// The passenger's last name
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// The passenger's seat number
        /// </summary>
        public int SeatNumber { get; set; }

        /// <summary>
        /// Returns string version of passenger object
        /// </summary>
        /// <returns>String of passengers first and last name</returns>
        public override String ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}

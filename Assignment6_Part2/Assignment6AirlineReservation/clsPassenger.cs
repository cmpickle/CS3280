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
    public class clsPassenger
    {
        #region class fields
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
        #endregion

        #region override methods
        /// <summary>
        /// Returns string version of passenger object
        /// </summary>
        /// <returns>String of passengers first and last name</returns>
        public override String ToString()
        {
            return FirstName + " " + LastName;
        }

        /// <summary>
        /// Compares two passenger objects to see if they are equivelant
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>True if equivelant otherwise false</returns>
        public override bool Equals(object obj)
        {
            if(obj is clsPassenger)
            {
                clsPassenger other = (clsPassenger)obj;

                return this.PassengerID == other.PassengerID;
            }
            return false;
        }
        #endregion
    }
}

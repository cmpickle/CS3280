using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Contains all of the sql queries for the program
    /// </summary>
    class clsSQL
    {
        /// <summary>
        /// Gets all flights from the database
        /// </summary>
        /// <returns>SQL string</returns>
        public String GetAllFlights()
        {
            string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
            return sSQL;
        }

        /// <summary>
        /// Selects all passengers for a given flight
        /// </summary>
        /// <param name="flightID">The flights ID</param>
        /// <returns>SQL string</returns>
        public String GetAllPassengersForFlight(String flightID)
        {
            string sSQL = String.Format("SELECT Passenger.Passenger_ID, First_Name, Last_Name, FPL.Seat_Number " +
                          "FROM Passenger, Flight_Passenger_Link FPL " +
                          "WHERE Passenger.Passenger_ID = FPL.Passenger_ID AND " +
                          "Flight_ID = {0}", flightID);
            return sSQL;
        }

    }
}

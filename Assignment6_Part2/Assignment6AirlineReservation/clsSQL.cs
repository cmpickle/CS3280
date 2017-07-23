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
            String sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
            return sSQL;
        }

        /// <summary>
        /// Selects all passengers for a given flight
        /// </summary>
        /// <param name="flightID">The flights ID</param>
        /// <returns>SQL string</returns>
        public String GetAllPassengersForFlight(String flightID)
        {
            String sSQL = String.Format("SELECT Passenger.Passenger_ID, First_Name, Last_Name, FPL.Seat_Number " +
                          "FROM Passenger, Flight_Passenger_Link FPL " +
                          "WHERE Passenger.Passenger_ID = FPL.Passenger_ID AND " +
                          "Flight_ID = {0}", flightID);
            return sSQL;
        }

        /// <summary>
        /// Selects the passenger who is in the seat on the flight selected
        /// </summary>
        /// <param name="flightID">The current flight</param>
        /// <param name="seatNum">The flight's seat number</param>
        /// <returns>SQL string</returns>
        public String GetPassengerFromSeat(String flightID, String seatNum)
        {
            String sSQL = String.Format("SELECT p.Passenger_ID, First_Name, Last_Name " +
                                        "FROM Passenger AS p " +
                                        "INNER JOIN Flight_Passenger_Link AS fpl " +
                                        "ON p.Passenger_ID = fpl.Passenger_ID " +
                                        "WHERE Flight_ID = {0} " +
                                        "AND Seat_Number = '{1}'", flightID, seatNum);
            return sSQL;
        }
    }
}
